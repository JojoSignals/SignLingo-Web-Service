using Application.Security.Exceptions;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.Security.Model.Commands;
using Domain.Security.Model.Entities;
using Domain.Security.Model.Responses;
using Domain.Security.Model.ValueObjects;
using Domain.Security.Repositories;
using Domain.Security.Services;
using Domain.Shared.Repository;

namespace Application.Security.Features.CommandServices;

public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IEncryptService _encryptService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    public UserCommandService(IUserRepository userRepository, IEncryptService encryptService, ITokenService tokenService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _encryptService = encryptService;
        _tokenService = tokenService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    
    public async Task<(UserResponse user, string token)> Handle(SignInCommand command)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(command.Email);
        if (existingUser == null)
            throw new InvalidCredentialsException(); 
        
        var isValidPassword = _encryptService.Verify(command.Password, existingUser.PasswordHash);
        if (!isValidPassword)
            throw new InvalidCredentialsException();
        
        var token = _tokenService.GenerateToken(existingUser);
        
        var userResponse = _mapper.Map<UserResponse>(existingUser);
        
        return (userResponse, token);
    }

    public async Task<UserResponse> Handle(SignUpCommand command)
    {
        var userWithSameEmail = await _userRepository.GetUserByEmailAsync(command.Email);
        if (userWithSameEmail != null)
            throw new DuplicatedUserEmailException(command.Email);
        
        var userWithSameUsername = await _userRepository.GetUserByUsernameAsync(command.Username);
        if (userWithSameUsername != null)
            throw new DuplicatedUserUsernameException(command.Username);
        
        var userEntity = _mapper.Map<User>(command);
        userEntity.Role = UserRoles.PLAYER;
        userEntity.PasswordHash = _encryptService.Encrypt (command.Password);

        await _userRepository.AddAsync(userEntity);
        await _unitOfWork.CompleteAsync();
        
        var userResponse = _mapper.Map<UserResponse>(userEntity);
        return userResponse;
    }

    public async Task<UserResponse> Handle(UpdateUserCommand command)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(command.Id);
        if (userToUpdate == null)
            throw new NotFoundEntityIdException(nameof(User), command.Id);
        
        var userWithSameUsername = await _userRepository.GetUserByUsernameAsync(command.Username);
        if (userWithSameUsername != null && userToUpdate.Id != userWithSameUsername.Id)
            throw new DuplicatedUserUsernameException(command.Username);

        _mapper.Map(command, userToUpdate);
        
        if (!string.IsNullOrWhiteSpace(command.CurrentPassword) &&
            !string.IsNullOrWhiteSpace(command.NewPassword))
        {
            var isValidPassword = _encryptService.Verify(command.CurrentPassword, userToUpdate.PasswordHash);
            if (!isValidPassword)
                throw new InvalidCurrentException();

            userToUpdate.PasswordHash = _encryptService.Encrypt(command.NewPassword);
        }

        await _userRepository.UpdateAsync(userToUpdate);
        await _unitOfWork.CompleteAsync();

        var userResponse = _mapper.Map<UserResponse>(userToUpdate);
        return userResponse;
        
    }

    public async Task<bool> Handle(DeleteUserCommand command)
    {
        var userToDelete = await _userRepository.DeleteAsync(command.Id);
        if (!userToDelete)
            throw new NotFoundEntityIdException(nameof(User), command.Id);
        
        await _unitOfWork.CompleteAsync();
        return true;
    }
}
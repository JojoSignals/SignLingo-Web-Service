using Application.Security.Exceptions;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.ExercisesManager.Model.ValueObjects;
using Domain.Security.Model.Commands;
using Domain.Security.Model.Entities;
using Domain.Security.Model.Responses;
using Domain.Security.Model.ValueObjects;
using Domain.Security.Repositories;
using Domain.Security.Services;
using Domain.Shared.Repository;
using Domain.Shared.Services;

namespace Application.Security.Features.CommandServices;

public class UserCommandService : IUserCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IEncryptService _encryptService;
    private readonly ITokenService _tokenService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IGoogleCaptchaService _captchaService;
    private readonly IImageManagerService _imageManagerService;
    private readonly IUserStatContextService _userStatContextService;

    public UserCommandService(IUserRepository userRepository, IEncryptService encryptService,
        ITokenService tokenService, IMapper mapper, IUnitOfWork unitOfWork, IGoogleCaptchaService captchaService,
        IImageManagerService imageService, IUserStatContextService userStatContextService)
    {
        _userRepository = userRepository;
        _encryptService = encryptService;
        _tokenService = tokenService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _captchaService = captchaService;
        _imageManagerService = imageService;
        _userStatContextService = userStatContextService;
    }

    public async Task<(UserResponse user, string token)> Handle(SignInCommand command)
    {
        /*var isCaptchaValid = await _captchaService.ValidateAsync(command.CaptchaResponse);
        if (!isCaptchaValid)
        {
            throw new InvalidCaptchaException();
        }*/

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
        var isCaptchaValid = await _captchaService.ValidateAsync(command.CaptchaResponse);
        if (!isCaptchaValid)
        {
            throw new InvalidCaptchaException();
        }

        var userWithSameEmail = await _userRepository.GetUserByEmailAsync(command.Email);
        if (userWithSameEmail != null)
            throw new DuplicatedUserEmailException(command.Email);

        var userWithSameUsername = await _userRepository.GetUserByUsernameAsync(command.Username);
        if (userWithSameUsername != null)
            throw new DuplicatedUserUsernameException(command.Username);

        var userEntity = _mapper.Map<User>(command);
        userEntity.Role = UserRoles.PLAYER;
        userEntity.PasswordHash = _encryptService.Encrypt(command.Password);

        await _userRepository.AddAsync(userEntity);
        await _unitOfWork.CompleteAsync();

        await _userStatContextService.CreateUserStat(userEntity.Id);

        var userResponse = _mapper.Map<UserResponse>(userEntity);
        return userResponse;
    }

    public async Task<UserResponse> Handle(int id, UpdateUserCommand command)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(id);
        if (userToUpdate == null)
            throw new NotFoundEntityIdException(nameof(User), id);

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

    public async Task<bool> Handle(UpdateUserPictureCommand command)
    {
        var userToUpdate = await _userRepository.GetByIdAsync(command.UserId);
        if (userToUpdate == null)
            throw new NotFoundEntityIdException(nameof(User), command.UserId);

        var username = userToUpdate.Username;

        var imageUploaded = await _imageManagerService.UploadAsync(username, command.PictureStream, MediaType.IMAGE);
        userToUpdate.ProfilePictureUrl = imageUploaded.Url;

        await _userRepository.UpdateAsync(userToUpdate);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}
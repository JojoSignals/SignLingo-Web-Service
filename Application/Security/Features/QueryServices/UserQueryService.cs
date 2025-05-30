using Application.Shared.Exceptions;
using AutoMapper;
using Domain.Security.Model.Entities;
using Domain.Security.Model.Queries;
using Domain.Security.Model.Responses;
using Domain.Security.Repositories;
using Domain.Security.Services;

namespace Application.Security.Features.QueryServices;

public class UserQueryService : IUserQueryService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    public UserQueryService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    
    public async Task<IReadOnlyCollection<UserResponse>> Handle(GetAllUsersQuery query)
    {
        var users = await _userRepository.GetAllAsync();
        if (users.Count == 0)
        {
            throw new NoEntitiesFoundException(nameof(User));
        }

        var result = _mapper.Map<List<UserResponse>>(users);
        return result;
    }

    public async Task<UserResponse?> Handle(GetUserByIdQuery query)
    {
        var user = await _userRepository.GetByIdAsync(query.Id);
        if (user == null)
        {
            throw new NoEntitiesFoundException(nameof(User));
        }
        
        var result = _mapper.Map<UserResponse>(user);
        return result;
    }

    public async Task<UserResponse?> Handle(GetUserByEmailQuery query)
    {
        var user = await _userRepository.GetUserByEmailAsync(query.Email);
        if (user == null)
        {
            throw new NoEntitiesFoundException(nameof(User));
        }

        var result = _mapper.Map<UserResponse>(user);
        return result;
    }

    public async Task<UserResponse?> Handle(GetUserByUsernameQuery query)
    {
        var user = await _userRepository.GetUserByUsernameAsync(query.Username);
        if (user == null)
        {
            throw new NoEntitiesFoundException(nameof(User));
        }

        var result = _mapper.Map<UserResponse>(user);
        return result;
    }
}
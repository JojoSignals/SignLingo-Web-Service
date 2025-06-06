using AutoMapper;
using Domain.Security.Model.Commands;
using Domain.Security.Model.Entities;
using Domain.Security.Model.Responses;

namespace Application.Shared.Mapping;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<User, UserResponse>();
        CreateMap<UpdateUserCommand, UserResponse>();
        CreateMap<SignUpCommand, UserResponse>();
        CreateMap<SignInCommand, UserResponse>();
    }
}
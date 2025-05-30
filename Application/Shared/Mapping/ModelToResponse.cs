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
        
        // De comando a entidad, ignorando el correo
        CreateMap<UpdateUserCommand, User>()
            .ForMember(dest => dest.Email, opt => opt.Ignore());
    }
}
using AutoMapper;
using Domain.Security.Model.Commands;
using Domain.Security.Model.Entities;

namespace Application.Shared.Mapping;

public class RequestToModel : Profile
{
    public RequestToModel()
    {
        CreateMap<UpdateUserCommand, User>()
            .ForMember(dest => dest.Email, opt => opt.Ignore());
        CreateMap<SignUpCommand, User>();
        CreateMap<SignInCommand, User>();
    }
    
}
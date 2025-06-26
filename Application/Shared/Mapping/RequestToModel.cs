using AutoMapper;
using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Commands.Exercise;
using Domain.ExercisesManager.Model.Commands.IconCommands;
using Domain.ExercisesManager.Model.Commands.Level;
using Domain.ExercisesManager.Model.Commands.Unit;
using Domain.ExercisesManager.Model.Entities;
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
        
        //ExerciseManagerMappers
        
        CreateMap<EditExerciseCommand, Exercise>();
        CreateMap<DeleteExerciseCommand, Exercise>();
        CreateMap<CreateExerciseCommand, Exercise>();

        CreateMap<EditUnitCommand, Unit>();
        CreateMap<DeleteUnitCommand, Unit>();
        CreateMap<CreateUnitCommand, Unit>();

        CreateMap<EditIconCommand, Icon>();
        CreateMap<DeleteIconCommand, Icon>();
        CreateMap<CreateIconCommand, Icon>();
        
        CreateMap<EditLevelCommand, Level>();
        CreateMap<DeleteLevelCommand, Level>();
        CreateMap<CreateLevelCommand, Level>();
    }
    
}
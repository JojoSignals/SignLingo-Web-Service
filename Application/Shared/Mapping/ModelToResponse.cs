using AutoMapper;
using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Commands.Exercise;
using Domain.ExercisesManager.Model.Commands.IconCommands;
using Domain.ExercisesManager.Model.Commands.Level;
using Domain.ExercisesManager.Model.Commands.Option;
using Domain.ExercisesManager.Model.Commands.Unit;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.Responses;
using Domain.Security.Model.Commands;
using Domain.Security.Model.Entities;
using Domain.Security.Model.Responses;
using Domain.UserStats.Model.Agreggates;
using Domain.UserStats.Model.Responses;

namespace Application.Shared.Mapping;

public class ModelToResponse : Profile
{
    public ModelToResponse()
    {
        CreateMap<User, UserResponse>();
        CreateMap<UpdateUserCommand, UserResponse>();
        CreateMap<SignUpCommand, UserResponse>();
        CreateMap<SignInCommand, UserResponse>();
        
        CreateMap<Option, OptionResponse>();
        CreateMap<CreateOptionCommand, OptionResponse>();
        CreateMap<EditOptionCommand, OptionResponse>();
        CreateMap<DeleteOptionCommand, OptionResponse>();
        
        // Exercises Manager
        CreateMap<Exercise, ExerciseResponse>();
        CreateMap<EditExerciseCommand, ExerciseResponse>();
        CreateMap<CreateExerciseCommand, ExerciseResponse>();
        CreateMap<DeleteExerciseCommand, ExerciseResponse>();

        CreateMap<Unit, UnitResponse>();
        CreateMap<EditUnitCommand, UnitResponse>();
        CreateMap<CreateUnitCommand, UnitResponse>();
        CreateMap<DeleteUnitCommand, UnitResponse>();
        
        CreateMap<Icon, IconResponse>();
        CreateMap<EditIconCommand, IconResponse>();
        CreateMap<CreateIconCommand, IconResponse>();
        CreateMap<DeleteIconCommand, IconResponse>();
        
        CreateMap<Level, LevelResponse>();
        CreateMap<EditLevelCommand, LevelResponse>();
        CreateMap<CreateLevelCommand, LevelResponse>();
        CreateMap<DeleteLevelCommand, LevelResponse>();
        //User Stats
        CreateMap<UserStat, UserStatsResponse>();
    }
}
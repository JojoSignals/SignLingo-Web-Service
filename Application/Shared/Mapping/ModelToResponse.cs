using AutoMapper;
using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Responses;
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
        
        // Exercises Manager
        CreateMap<Exercise, ExerciseResponse>();
        CreateMap<EditExerciseCommand, ExerciseResponse>();
        CreateMap<DeleteExerciseCommand, ExerciseResponse>();
        CreateMap<CreateExerciseCommand, ExerciseResponse>();
    }
}
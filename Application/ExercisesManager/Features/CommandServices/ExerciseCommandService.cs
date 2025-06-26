using Application.ExercisesManager.Exceptions;
using Application.ExercisesManager.Exceptions.Exercise;
using AutoMapper;
using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Commands.Exercise;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services;
using Domain.ExercisesManager.Services.Exercise;
using Domain.Shared.Repository;

namespace Application.ExercisesManager.Features.CommandServices;

public class ExerciseCommandService : IExerciseCommandService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ExerciseCommandService(IExerciseRepository commandService, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _exerciseRepository = commandService;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ExerciseResponse> Handle(CreateExerciseCommand command)
    {
        var exerciseRequest = _mapper.Map<Exercise>(command);
        
        
        await _exerciseRepository.AddAsync(exerciseRequest);
        await _unitOfWork.CompleteAsync();
        
        var exerciseResponse = _mapper.Map<ExerciseResponse>(exerciseRequest);

        return exerciseResponse;
    }

    public async Task<bool> Handle(EditExerciseCommand command)
    {
        var existingExercise = await _exerciseRepository.GetByIdAsync(command.Id);

        if (existingExercise == null)
        {
            throw new ExerciseNotFoundException(command.Id);
        }
        
        existingExercise.QuestionWord = command.QuestionWord;
        
        await _exerciseRepository.UpdateAsync(existingExercise);
        await _unitOfWork.CompleteAsync();
        
        return true;
    }

    public async Task<bool> Handle(DeleteExerciseCommand command)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(command.Id);

        if (exercise == null)
        {
            throw new ExerciseNotFoundException(command.Id);
        }
        
        await _exerciseRepository.DeleteAsync(exercise.Id);
        await _unitOfWork.CompleteAsync();
        
        return true;
    }
    
}
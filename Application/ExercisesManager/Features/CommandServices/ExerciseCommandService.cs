using Application.ExercisesManager.Exceptions;
using Application.ExercisesManager.Exceptions.Exercise;
using AutoMapper;
using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Commands.Exercise;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services;
using Domain.ExercisesManager.Services.Exercise;
using Domain.Shared.Repository;

namespace Application.ExercisesManager.Features.CommandServices;

public class ExerciseCommandService : IExerciseCommandService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IOptionRepository _optionRepository;
    private readonly ILevelRepository _levelRepository;

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public ExerciseCommandService(IExerciseRepository exerciseRepository, IOptionRepository optionRepository, ILevelRepository levelRepository,
        IMapper mapper, IUnitOfWork unitOfWork)
    {
        _exerciseRepository = exerciseRepository;
        _levelRepository = levelRepository;
        _optionRepository = optionRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<ExerciseResponse> Handle(CreateExerciseCommand command)
    {
        var exerciseRequest = _mapper.Map<Exercise>(command);
        var level = await _levelRepository.GetByIdAsync(command.LevelId);

        if (level != null)
        {
            Console.WriteLine("Level already exists");
        }

        exerciseRequest.LevelId = command.LevelId;
        exerciseRequest.Level = level;

        if (level.Exercises == null)
        {
            level.Exercises = [];
        }
        level.Exercises.Add(exerciseRequest);

        foreach (var optionId in command.OptionsId)
        {
            var option = await _optionRepository.GetByIdAsync(optionId);
            Console.WriteLine("Option ID " + option?.Word ?? "null");
            if (option == null) continue;

            var exerciseOption = new ExerciseOption()
            {
                ExerciseId = exerciseRequest.Id,
                OptionId = option.Id,
                IsCorrect = false,
                Exercise = exerciseRequest,
                Option = option
            };
            exerciseRequest.ExerciseOptions = [];
            exerciseRequest.ExerciseOptions.Add(exerciseOption);
        }


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
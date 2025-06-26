using Application.ExercisesManager.Exceptions;
using Application.ExercisesManager.Exceptions.Exercise;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.Queries;
using Domain.ExercisesManager.Model.Queries.Exercise;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services;
using Domain.ExercisesManager.Services.Exercise;

namespace Application.ExercisesManager.Features.QueryServices;

public class ExerciseQueryService : IExerciseQueryService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IQuestionTypeRepository _questionTypeRepository;
    private readonly IMapper _mapper;

    public ExerciseQueryService(IExerciseRepository exerciseRepository,IQuestionTypeRepository questionTypeRepository, IMapper mapper)
    {
        _exerciseRepository = exerciseRepository;
        _questionTypeRepository = questionTypeRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<ExerciseResponse>> Handle(GetAllExercisesQuery query)
    {
        var exercises = await _exerciseRepository.GetAllAsync();
        if (exercises.Count == 0)
        {
            throw new NoEntitiesFoundException(nameof(Exercise));
        }
        
        var response = _mapper.Map<IReadOnlyCollection<ExerciseResponse>>(exercises);
        return response;
    }

    public async Task<ExerciseResponse?> Handle(GetExerciseByIdQuery query)
    {
        var exercise = await _exerciseRepository.GetByIdAsync(query.Id);
        if (exercise == null)
        {
            throw new ExerciseNotFoundException(query.Id);
        }
        
        var response = _mapper.Map<ExerciseResponse>(exercise);
        return response;
    }

    public async Task<IReadOnlyCollection<ExerciseResponse>> Handle(GetAllExercisesByQuestionTypeIdQuery query)
    {
        var questionType = await _questionTypeRepository.GetByIdAsync(query.QuestionTypeId);
        if (questionType == null)
        {
            throw new NotFoundEntityIdException(nameof(QuestionTypeEntity), query.QuestionTypeId);
        }

        var exercises = await _exerciseRepository.GetAllExercisesByQuestionTypeIdAsync(query.QuestionTypeId);
        var response = _mapper.Map<IReadOnlyCollection<ExerciseResponse>>(exercises);
        return response;
    }
}
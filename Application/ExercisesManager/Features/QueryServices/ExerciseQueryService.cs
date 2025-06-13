using Application.ExercisesManager.Exceptions;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Queries;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services;

namespace Application.ExercisesManager.Features.QueryServices;

public class ExerciseQueryService : IExerciseQueryService
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IMapper _mapper;

    public ExerciseQueryService(IExerciseRepository exerciseRepository, IMapper mapper)
    {
        _exerciseRepository = exerciseRepository;
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
}
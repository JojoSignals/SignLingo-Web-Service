using Application.ExercisesManager.Exceptions.Unit;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.Queries.Unit;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services.Unit;

namespace Application.ExercisesManager.Features.QueryServices;

public class UnitQueryService : IUnitQueryService
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;

    public UnitQueryService(IUnitRepository unitRepository, IMapper mapper)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<UnitResponse>> Handle(GetAllUnitsQuery query)
    {
        var units = await _unitRepository.GetAllAsync();
        if (units.Count == 0)
        {
            throw new NoEntitiesFoundException(nameof(Unit));
        }
        
        var response = _mapper.Map<IReadOnlyCollection<UnitResponse>>(units);
        return response;
    }

    public async Task<UnitResponse?> Handle(GetUnitByIdQuery query)
    {
        var unit = await _unitRepository.GetByIdAsync(query.Id);
        if (unit == null)
        {
            throw new UnitNotFoundException(query.Id);
        }
        
        var response = _mapper.Map<UnitResponse>(unit);
        return response;
    }
}
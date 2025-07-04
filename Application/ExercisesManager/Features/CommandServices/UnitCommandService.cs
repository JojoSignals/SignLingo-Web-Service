using Application.ExercisesManager.Exceptions.Unit;
using AutoMapper;
using Domain.ExercisesManager.Model.Commands.Unit;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services.Unit;
using Domain.Shared.Repository;

namespace Application.ExercisesManager.Features.CommandServices;

public class UnitCommandService : IUnitCommandService
{
    private readonly IUnitRepository _unitRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public UnitCommandService(IUnitRepository unitRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _unitRepository = unitRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    //Create
    public async Task<UnitResponse> Handle(CreateUnitCommand command)
    {
        var unitRequest = _mapper.Map<Unit>(command);
        Console.WriteLine("UnitRequest: " + unitRequest.Name);

        await _unitRepository.AddAsync(unitRequest);
        await _unitOfWork.CompleteAsync();
        
        var unitResponse = _mapper.Map<UnitResponse>(unitRequest);
        return unitResponse;
        
    }

    //Edit
    public async Task<bool> Handle(EditUnitCommand command)
    {
        var existingUnit = await _unitRepository.GetByIdAsync(command.Id);
        
        if (existingUnit == null)
        {
            throw new UnitNotFoundException(command.Id);
        }
        
        existingUnit.Name = command.Name;
        
        await _unitRepository.UpdateAsync(existingUnit);
        await _unitOfWork.CompleteAsync();

        return true;
    }

    //Delete
    public async Task<bool> Handle(DeleteUnitCommand command)
    {
        var unit = await _unitRepository.GetByIdAsync(command.Id);

        if (unit == null)
        {
            throw new UnitNotFoundException(command.Id);
        }

        await _unitRepository.DeleteAsync(unit.Id);
        await _unitOfWork.CompleteAsync();
        
        return true;
    }
}
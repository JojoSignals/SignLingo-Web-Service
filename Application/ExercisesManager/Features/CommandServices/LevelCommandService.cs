using Application.ExercisesManager.Exceptions.Level;
using AutoMapper;
using Domain.ExercisesManager.Model.Aggregates;
using Domain.ExercisesManager.Model.Commands.Level;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services.Level;
using Domain.Shared.Repository;

namespace Application.ExercisesManager.Features.CommandServices;

public class LevelCommandService : ILevelCommandService
{
    private readonly ILevelRepository _levelRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public LevelCommandService(ILevelRepository levelRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _levelRepository = levelRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<LevelResponse> Handle(CreateLevelCommand command)
    {
        var levelRequest = _mapper.Map<Level>(command);
        
        await _levelRepository.AddAsync(levelRequest);
        await _unitOfWork.CompleteAsync();
        
        var levelResponse = _mapper.Map<LevelResponse>(levelRequest);
        return levelResponse;
    }

    public async Task<bool> Handle(EditLevelCommand command)
    {
        var existingLevel = await _levelRepository.GetByIdAsync(command.Id);
        if (existingLevel == null)
        {
            throw new LevelNotFoundException(command.Id);
        }
        
        existingLevel.LevelName = command.LevelName;
        existingLevel.LevelDescription = command.LevelDescription;
        existingLevel.ExperienceRequiered = command.ExperienceRequiered;
        existingLevel.TotalQuestions = command.TotalQuestions;
        
        await _levelRepository.UpdateAsync(existingLevel);
        await _unitOfWork.CompleteAsync();

        return true;
    }

    public async Task<bool> Handle(DeleteLevelCommand command)
    {
        var level = await _levelRepository.GetByIdAsync(command.LevelId);

        if (level == null)
        {
            throw new LevelNotFoundException(command.LevelId);
        }
        
        await _levelRepository.DeleteAsync(command.LevelId);
        await _unitOfWork.CompleteAsync();
        
        return true;
    }
}
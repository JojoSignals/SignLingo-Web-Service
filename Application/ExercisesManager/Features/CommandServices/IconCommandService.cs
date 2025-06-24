using Application.ExercisesManager.Exceptions;
using AutoMapper;
using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services;
using Domain.Shared.Repository;

namespace Application.ExercisesManager.Features.CommandServices;

public class IconCommandService : IIconCommandService
{
    private readonly IIconRepository _iconRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public IconCommandService(IIconRepository iconRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _iconRepository = iconRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }


    public async Task<IconResponse> Handle(CreateIconCommand command)
    {
        var iconRequest = _mapper.Map<Icon>(command);
        
        await _iconRepository.AddAsync(iconRequest);
        await _unitOfWork.CompleteAsync();
        
        var iconResponse = _mapper.Map<IconResponse>(iconRequest);
        return iconResponse;
    }

    public async Task<bool> Handle(EditIconCommand command)
    {
        var existingIcon = await _iconRepository.GetByIdAsync(command.Id);
        if (existingIcon == null)
        {
            throw new IconNotFoundException(command.Id);
        }
        
        existingIcon.UrlImage = command.UrlImage;
        
        await _iconRepository.UpdateAsync(existingIcon);
        await _unitOfWork.CompleteAsync();
        
        return true;
    }

    public async Task<bool> Handle(DeleteIconCommand command)
    {
        var icon = await _iconRepository.GetByIdAsync(command.Id);
        if (icon == null)
        {
            throw new IconNotFoundException(command.Id);
        }

        await _iconRepository.DeleteAsync(icon.Id);
        await _unitOfWork.CompleteAsync();
        
        return true;
    }
}
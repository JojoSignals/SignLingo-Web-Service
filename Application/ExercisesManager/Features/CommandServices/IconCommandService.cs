using System.Globalization;
using Application.ExercisesManager.Exceptions;
using Application.ExercisesManager.Exceptions.IconExceptions;
using AutoMapper;
using Domain.ExercisesManager.Model.Commands;
using Domain.ExercisesManager.Model.Commands.IconCommands;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services;
using Domain.ExercisesManager.Services.IconServices;
using Domain.Shared.Repository;
using Domain.Shared.Services;

namespace Application.ExercisesManager.Features.CommandServices;

public class IconCommandService : IIconCommandService
{
    private readonly IIconRepository _iconRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageManagerService _imageManagerService;

    public IconCommandService(IIconRepository iconRepository, IMapper mapper, IUnitOfWork unitOfWork,
        IImageManagerService imageManagerService)
    {
        _iconRepository = iconRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _imageManagerService = imageManagerService;
    }


    public async Task<IconResponse> Handle(CreateIconCommand command)
    {
        var imageResponse = await _imageManagerService.UploadAsync(new DateTime().ToString(CultureInfo.InvariantCulture), command.Image);
        var imageUrl = imageResponse.Url;

        // var iconRequest = _mapper.Map<Icon>(command);

        var iconRequest = new Icon()
        {
            UrlImage = imageUrl
        };

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
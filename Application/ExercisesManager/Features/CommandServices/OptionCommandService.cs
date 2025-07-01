using System.Globalization;
using Application.ExercisesManager.Exceptions.Option;
using AutoMapper;
using Domain.ExercisesManager.Model.Commands.Option;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services.Option;
using Domain.Shared.Repository;
using Domain.Shared.Services;

namespace Application.ExercisesManager.Features.CommandServices;

public class OptionCommandService : IOptionCommandService
{
    private readonly IOptionRepository _optionRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IImageManagerService _imageManagerService;

    public OptionCommandService(IOptionRepository optionRepository, IMapper mapper, IUnitOfWork unitOfWork, IImageManagerService imageManagerService)
    {
        _optionRepository = optionRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _imageManagerService = imageManagerService;
    }


    public async Task<OptionResponse> Handle(CreateOptionCommand command)
    {
        //var optionRequest = _mapper.Map<Option>(command);

        var imageResponse =
            await _imageManagerService.UploadAsync(new DateTime().ToString(CultureInfo.InvariantCulture),
                command.Image);
        
        var imageUrl = imageResponse.Url;

        var option = new Option()
        {
            Word = command.Word,
            UrlImage = imageResponse.Url,
        };
        
        await _optionRepository.AddAsync(option);
        await _unitOfWork.CompleteAsync();
        
        var optionResponse = _mapper.Map<OptionResponse>(option);
        
        return optionResponse;
    }

    public async Task<bool> Handle(EditOptionCommand command)
    {
        var existingOption = await _optionRepository.GetByIdAsync(command.Id);
        if (existingOption == null)
        {
            throw new OptionNotFoundException(command.Id);
        }
        
        existingOption.Word = command.Word;
        existingOption.UrlImage = command.UrlImage;
        
        await _optionRepository.UpdateAsync(existingOption);
        await _unitOfWork.CompleteAsync();

        return true;
    }

    public async Task<bool> Handle(DeleteOptionCommand command)
    {
        var option = await _optionRepository.GetByIdAsync(command.Id);
        if (option == null)
        {
            throw new OptionNotFoundException(command.Id);
        }

        await _optionRepository.DeleteAsync(option.Id);
        await _unitOfWork.CompleteAsync();

        return true;
    }
}
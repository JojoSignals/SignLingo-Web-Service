using Application.ExercisesManager.Exceptions.Option;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.Queries.Option;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services.Option;

namespace Application.ExercisesManager.Features.QueryServices;

public class OptionQueryService : IOptionQueryService
{
    private readonly IOptionRepository _optionRepository;
    private readonly IMapper _mapper;

    public OptionQueryService(IOptionRepository optionRepository, IMapper mapper)
    {
        _optionRepository = optionRepository;
        _mapper = mapper;
    }


    public async Task<IReadOnlyCollection<OptionResponse>> Handle(GetAllOptionsQuery query)
    {
        var option = await _optionRepository.GetAllAsync();
        if (option.Count == 0)
        {
            throw new NoEntitiesFoundException(nameof(Option));
        }
        
        var response = _mapper.Map<IReadOnlyCollection<OptionResponse>>(option);
        return response;
    }

    public async Task<OptionResponse?> Handle(GetOptionByIdQuery query)
    {
        var option = await _optionRepository.GetByIdAsync(query.Id);
        if (option == null)
        {
            throw new OptionNotFoundException(query.Id);
        }
        var response = _mapper.Map<OptionResponse>(option);

        return response;
    }
}
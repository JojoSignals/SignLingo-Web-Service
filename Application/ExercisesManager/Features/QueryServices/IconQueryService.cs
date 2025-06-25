using Application.ExercisesManager.Exceptions;
using Application.Shared.Exceptions;
using AutoMapper;
using Domain.ExercisesManager.Model.Entities;
using Domain.ExercisesManager.Model.Queries;
using Domain.ExercisesManager.Model.Responses;
using Domain.ExercisesManager.Repositories;
using Domain.ExercisesManager.Services;
using Domain.Shared.Repository;

namespace Application.ExercisesManager.Features.QueryServices;

public class IconQueryService : IIconQueryService
{
    private readonly IIconRepository _iconRepository;
    private readonly IMapper _mapper;

    public IconQueryService(IIconRepository iconRepository, IMapper mapper)
    {
        _iconRepository = iconRepository;
        _mapper = mapper;
    }

    public async Task<IReadOnlyCollection<IconResponse>> Handle(GetAllIconsQuery query)
    {
        var icon = await _iconRepository.GetAllAsync();
        if (icon.Count == 0)
        {
            throw new NoEntitiesFoundException(nameof(Icon));
        }
        
        var response = _mapper.Map<IReadOnlyCollection<IconResponse>>(icon);
        return response;
    }

    public async Task<IconResponse?> Handle(GetIconByIdQuery query)
    {
        var icon = await _iconRepository.GetByIdAsync(query.Id);
        if (icon == null)
        {
            throw new IconNotFoundException(query.Id);
        }
        
        var response = _mapper.Map<IconResponse>(icon);
        return response;
    }
}
using AutoMapper;
using Domain.ExercisesManager.Services;
using Domain.Shared.Repository;

namespace Application.ExercisesManager.Features.CommandServices;

public class IconCommandService : IIconCommandService
{
    private readonly IIconCommandService _iconCommandService;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    
    
}
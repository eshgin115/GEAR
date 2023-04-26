using AutoMapper;
using GearVeloAPI.Contracts.Identity;
using GearVeloAPI.Contracts.Root;
using GearVeloAPI.Database;
using GearVeloAPI.Helper.Services.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace GearVeloAPI.Helper.Controller;

[Route("utility")]
[ApiController]
public class UtilityController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly ILogger<UtilityController> _logger;
    private readonly IMapper _mapper;
    private readonly IEndpointService _endpointService;
    public UtilityController(
        DataContext dataContext,
        ILogger<UtilityController> logger,
        IMapper mapper,
        IEndpointService endpointService)
    {
        _dataContext = dataContext;
        _logger = logger;
        _mapper = mapper;
        _endpointService = endpointService;
    }
    [HttpGet("urls")]
    public IActionResult Add()
    {

        return Ok(_endpointService.GetEndpointsWithHttpGet());
    }
}

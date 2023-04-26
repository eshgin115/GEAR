using GearVeloAPI.Admin.Dtos.Navabr;
using GearVeloAPI.Admin.Services.Concretes;
using GearVeloAPI.Contracts.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GearVeloAPI.Admin.Controllers;

[Route("navbar")]
[ApiController]
//[Authorize(Roles = RoleNames.ADMIN)]

public class NavbarController : ControllerBase
{
    private readonly INavbarService _navbarService;

    public NavbarController(INavbarService navbarService)
    {
        _navbarService = navbarService;
    }
    #region List
    [HttpGet("navbars")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _navbarService.ListAsync());
    }
    #endregion

    #region add

    [HttpPost("navbar")]
    public async Task<IActionResult> AddAsync(NavbarCreateDto dto)
    {
        return Created(string.Empty, await _navbarService.AddAsync(dto));

    }
    #endregion

    #region Update

    [HttpPut("navbar/{id}")]
    public async Task<IActionResult> UpdateAsync(int id, NavbarUpdateDto dto)
    {
        return Ok(await _navbarService.UpdateAsync(id, dto));
    }
    #endregion

    #region delete
    [HttpDelete("navbar/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _navbarService.DeleteAsync(id);

        return NoContent();
    }
    #endregion
}
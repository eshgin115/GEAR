using GearVeloAPI.Admin.Dtos.Subnavbar;
using GearVeloAPI.Admin.Services.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GearVeloAPI.Admin.Controllers;

[Route("subnavbar")]
[ApiController]
public class SubnavbarController : ControllerBase
{
    private readonly ISubnavbarService _subnavbarService;

    public SubnavbarController(ISubnavbarService subnavbarService)
    {
        _subnavbarService = subnavbarService;
    }
    #region List
    [HttpGet("subnavbars")]
    public async Task<IActionResult> ListAsync()
    {
        return Ok(await _subnavbarService.ListAsync());
    }
    #endregion

    #region Add
    [HttpPost("subnavbar")]
    public async Task<IActionResult> AddAsync(SubnavbarCreateDto dto)
    {
        return Created(string.Empty, await _subnavbarService.AddAsync(dto));
    }

    #endregion

    #region Update
    [HttpPut("subnavbar/{id}")]
    public async Task<IActionResult> UpdateAsync(int id, SubnavbarUpdateDto dto)
    {
        return Ok(await _subnavbarService.UpdateAsync(id, dto));
    }

    #endregion

    #region delete
    [HttpDelete("subnavbar/{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _subnavbarService.DeleteAsync(id);

        return NoContent();
    }
    #endregion
}

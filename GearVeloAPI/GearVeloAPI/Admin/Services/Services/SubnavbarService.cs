﻿using AutoMapper;
using GearVeloAPI.Admin.Dtos.Subnavbar;
using GearVeloAPI.Admin.Services.Concretes;
using GearVeloAPI.Contracts.ModelName;
using GearVeloAPI.Database;
using GearVeloAPI.Database.Models;
using GearVeloAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GearVeloAPI.Admin.Services.Services;

public class SubnavbarService : ISubnavbarService
{
    private readonly DataContext _dataContext;
    private readonly ILogger<SubnavbarService> _logger;
    private readonly IMapper _mapper;

    public SubnavbarService(DataContext dataContext, ILogger<SubnavbarService> logger, IMapper mapper)
    {
        _dataContext = dataContext;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<List<SubnavbarListItemDto>> ListAsync()
    {
        var subnavbars = await _dataContext.Subnavbars.Include(s => s.Navbar).AsNoTracking().ToListAsync();
        return _mapper.Map<List<SubnavbarListItemDto>>(subnavbars);
    }
    public async Task<SubnavbarListItemDto> AddAsync(SubnavbarCreateDto dto)
    {
        if (!_dataContext.Navbars.Any(n => n.Id == dto.NavbarId))
            throw new NotFoundException(DomainModelName.NAVBAR, dto.NavbarId);

        var subnavbar = _mapper.Map<Subnavbar>(dto);
        await _dataContext.Subnavbars.AddAsync(subnavbar);

        await _dataContext.SaveChangesAsync();
        var subnavbarInDb = await _dataContext.Subnavbars.Include(s => s.Navbar).FirstAsync(s => s.Id == subnavbar.Id);

        return _mapper.Map<SubnavbarListItemDto>(subnavbarInDb);
    }

    public async Task<SubnavbarListItemDto> UpdateAsync(int id, SubnavbarUpdateDto dto)
    {
        var subnavbar = await _dataContext.Subnavbars.FirstOrDefaultAsync(b => b.Id == id)
            ?? throw new NotFoundException(DomainModelName.SUBNAVBAR, id);


        if (!_dataContext.Navbars.Any(n => n.Id == dto.NavbarId))
            throw new NotFoundException(DomainModelName.NAVBAR, id);

        _mapper.Map(dto, subnavbar);
        await _dataContext.SaveChangesAsync();


        return _mapper.Map<SubnavbarListItemDto>(subnavbar);

    }

    public async Task DeleteAsync(int id)
    {
        var subnavbar = await _dataContext.Subnavbars.FirstOrDefaultAsync(b => b.Id == id)
            ?? throw new NotFoundException(DomainModelName.SUBNAVBAR, id);

        _dataContext.Subnavbars.Remove(subnavbar);
        await _dataContext.SaveChangesAsync();

    }
}

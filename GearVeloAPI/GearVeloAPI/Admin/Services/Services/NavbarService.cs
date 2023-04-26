using AutoMapper;
using GearVeloAPI.Admin.Dtos.Navabr;
using GearVeloAPI.Admin.Services.Concretes;
using GearVeloAPI.Contracts.ModelName;
using GearVeloAPI.Database;
using GearVeloAPI.Database.Models;
using GearVeloAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GearVeloAPI.Admin.Services.Services;

public class NavbarService : INavbarService
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    public NavbarService
        (DataContext dataContext,
        IMapper mapper)
    {
        _dataContext = dataContext;
        _mapper = mapper;
    }
    public async Task<List<NavbarListItemDto>> ListAsync()
    {
        var navbars = await _dataContext.Navbars.AsNoTracking().ToListAsync();
        return _mapper.Map<List<NavbarListItemDto>>(navbars);
    }

    public async Task<NavbarListItemDto> AddAsync(NavbarCreateDto dto)
    {
        if (_dataContext.Navbars.Any(n => n.Order == dto.Order))
            throw new ValidationException("order allready used");

        var navbar = _mapper.Map<Navbar>(dto);

        await _dataContext.Navbars.AddAsync(navbar);

        await _dataContext.SaveChangesAsync();


        return _mapper.Map<NavbarListItemDto>(navbar);
    }

    public async Task<NavbarListItemDto> UpdateAsync(int id, NavbarUpdateDto dto)
    {
        var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id)
            ?? throw new NotFoundException(DomainModelName.NAVBAR, id);



        if (!_dataContext.Navbars.Any(n => n.Id == id) && !(dto.Order == navbar.Order))
            throw new ValidationException("This order used another navbar");

        _mapper.Map(dto, navbar);


        await _dataContext.SaveChangesAsync();

        return _mapper.Map<NavbarListItemDto>(navbar);
    }
    public async Task DeleteAsync(int id)
    {
        var navbar = await _dataContext.Navbars.FirstOrDefaultAsync(n => n.Id == id)
            ?? throw new NotFoundException(DomainModelName.NAVBAR, id);

        _dataContext.Navbars.Remove(navbar);

        await _dataContext.SaveChangesAsync();
    }
}

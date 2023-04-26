using AutoMapper;
using GearVeloAPI.Admin.Dtos.Navbar;
using GearVeloAPI.Database.Models;

namespace GearVeloAPI.Admin.Mappers;

public class NavbarMapper : Profile
{
    public NavbarMapper()
    {
        CreateMap<Navbar, NavbarListItemDto>()
             .ForMember(d => d.Id, o => o.MapFrom(s => s.Id));

        CreateMap<NavbarCreateDto, Navbar>()
          .ForMember(d => d.Id, opt => opt.Ignore());

        CreateMap<Navbar, NavbarUpdateDto>();

        CreateMap<NavbarUpdateDto, Navbar>()
             .ForMember(d => d.Id, opt => opt.Ignore());

    }
}
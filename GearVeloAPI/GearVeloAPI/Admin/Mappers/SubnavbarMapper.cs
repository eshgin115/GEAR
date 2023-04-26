using AutoMapper;
using GearVeloAPI.Admin.Dtos.Subnavbar;
using GearVeloAPI.Database.Models;

namespace GearVeloAPI.Admin.Mappers;

public class SubnavbarMapper : Profile
{
    public SubnavbarMapper()
    {
        CreateMap<Subnavbar, SubnavbarListItemDto>()
              .ForMember(d => d.NavbarName, o => o.MapFrom(s => s.Navbar!.Name));

        CreateMap<SubnavbarCreateDto, Subnavbar>();

        CreateMap<SubnavbarUpdateDto, Subnavbar>()
              .ForMember(d => d.Id, o => o.Ignore());
    }
}

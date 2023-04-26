using GearVeloAPI.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GearVeloAPI.Database.Configurations;
public class NavbarConfigurations : IEntityTypeConfiguration<Navbar>
{
    public void Configure(EntityTypeBuilder<Navbar> builder)
    {
        builder
           .ToTable("Navbars");
    }
}

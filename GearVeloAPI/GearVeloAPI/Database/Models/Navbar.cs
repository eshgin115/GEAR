using GearVeloAPI.Database.Models.Common;

namespace GearVeloAPI.Database.Models;

public class Navbar : BaseEntity<int>, IAuditable
{
    public string Name { get; set; } = default!;
    public string ToURL { get; set; } = default!;
    public int Order { get; set; } = default!;
    public bool IsViewOnHeader { get; set; } = default!;
    public bool IsViewOnFooter { get; set; } = default!;

    public List<Subnavbar>? Subnavbars { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
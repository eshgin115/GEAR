﻿using GearVeloAPI.Database.Models.Common;

namespace GearVeloAPI.Database.Models;


public class Subnavbar : BaseEntity<int>
{
    public string Name { get; set; } = default!;
    public string ToURL { get; set; } = default!;
    public int Order { get; set; } = default!;
    public int NavbarId { get; set; } = default!;   
    public Navbar? Navbar { get; set; }
}

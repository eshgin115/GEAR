﻿using System.ComponentModel.DataAnnotations;

namespace GearVeloAPI.Admin.Dtos.Navabr;

public class NavbarCreateDto
{
    [Required]
    public string Name { get; set; } = default!;
    [Required]
    public string ToURL { get; set; } = default!;
    [Required]
    public int Order { get; set; }
    [Required]
    public bool IsViewOnHeader { get; set; }
    [Required]
    public bool IsViewOnFooter { get; set; }
}
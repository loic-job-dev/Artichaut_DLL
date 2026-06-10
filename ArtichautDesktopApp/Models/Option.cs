using System;

namespace ArtichautDesktopApp.Models;

public class Option
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Price Price { get; set; }
}
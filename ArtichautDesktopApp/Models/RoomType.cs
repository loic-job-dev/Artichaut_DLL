using System;

namespace ArtichautDesktopApp.Models;

public class RoomType
{
    public Guid Id { get; init; }
    public string Type { get; init; }
    public string Description { get; init; }
    public int Price { get; init; }
}
using ArtichautDesktopApp.Models;
using ArtichautLibrary;

namespace ArtichautDesktopApp.Mappers;

public static class RoomMapper
{
    public static Room ToModel(this RoomResponse response)
    {
        return new Room
        {
            Id = response.Id,
            Number = response.Number
        };
    }
}
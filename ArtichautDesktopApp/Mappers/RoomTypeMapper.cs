using ArtichautDesktopApp.Models;
using ArtichautLibrary;

namespace ArtichautDesktopApp.Mappers;

public static class RoomTypeMapper
{
    public static RoomType ToModel(this RoomTypeResponse response)
    {
        return new RoomType
        {
            Id = response.Id,
            Type = response.Type,
            Description = response.Description,
            Price = response.Price
        };
    }
}
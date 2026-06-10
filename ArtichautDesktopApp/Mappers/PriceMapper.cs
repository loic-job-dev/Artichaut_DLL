using ArtichautDesktopApp.Models;
using ArtichautLibrary;

namespace ArtichautDesktopApp.Mappers;

public static class PriceMapper
{
    public static Price ToModel(this PriceResponse response)
    {
        return new Price
        {
            Id = response.Id,
            Description = response.Description,
            PriceValue = response.Price
        };
    }
}
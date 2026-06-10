using ArtichautDesktopApp.Models;
using ArtichautLibrary;

namespace ArtichautDesktopApp.Mappers;

public static class OptionMapper
{
    public static Option ToModel(this OptionResponse response)
    {
        return new Option
        {
            Id = response.Id,
            Name = response.Name,
            Description = response.Description,
            Price = response.Price.ToModel()
        };
    }
}
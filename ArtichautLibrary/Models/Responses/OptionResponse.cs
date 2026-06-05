namespace ArtichautLibrary;

/// <summary>
/// Represents an option returned by the Artichaut API.
/// </summary>
/// <param name="Id"> Unique identifier of the option. </param>
/// <param name="Name"> Name of the option. </param>
/// <param name="Description"> Description of the option. </param>
/// <param name="Price"> The price response linked at the option. </param>
public record OptionResponse(
    Guid Id,
    string Name,
    string Description,
    PriceResponse Price
    );
namespace ArtichautLibrary;

/// <summary>
/// Represents a price returned by the Artichaut API.
/// </summary>
/// <param name="Id"> Unique identifier of the option. </param>
/// <param name="Price"> The numeric value of the price. </param>
/// <param name="Description"> Description of the price. </param>
public record PriceResponse(
    Guid Id,
    int Price,
    string Description
    );
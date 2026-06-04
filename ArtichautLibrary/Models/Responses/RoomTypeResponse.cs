namespace ArtichautLibrary;

/// <summary>
/// Represents a room type available in the Artichaut hotel.
/// </summary>
/// <param name="Id"> Unique identifier of the room type. </param>
/// <param name="Type"> Room type code (for example: STD or STE). </param>
/// <param name="Description"> Description of the room type. </param>
/// <param name="RoomQuantity"> Total number of rooms available for this room type. </param>
/// <param name="Availability"> Indicates whether this room type is currently available. </param>
/// <param name="Capacity"> Maximum number of guests allowed in the room. </param>
/// <param name="Price"> Price per night for this room type. </param>
public record RoomTypeResponse(
    Guid Id,
    string Type,
    string Description,
    int RoomQuantity,
    bool Availability,
    int Capacity,
    int Price
    );
namespace ArtichautLibrary;

public record SignUpRequest(
    string Email,
    string Password,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string Pseudo,
    int StreetNumber,
    string StreetType,
    string StreetName,
    string? AddressComplement,
    string ZipCode,
    string City
);
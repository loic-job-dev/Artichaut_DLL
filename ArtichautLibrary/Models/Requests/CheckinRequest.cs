namespace ArtichautLibrary;

internal record CheckinRequest(
    string Status,
    DateOnly StartBookedDate,
    string RoomType
    );
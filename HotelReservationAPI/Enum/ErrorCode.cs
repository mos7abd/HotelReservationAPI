namespace HotelReservationAPI.Enum
{
    public enum ErrorCode
    {
        None = 200,                       //ok 

        RoomNotFound = 100,
        UnKnown = 500,                   // Internal Server Error
        BadRequest = 400,                   // Bad Request
        Unauthorized = 401,                 // Unauthorized
        NotFound = 404,                     // Not Found
        Conflict = 409,                     // Conflict
        InternalServerError = 500,



        RoomNotAvailable,
        RoomAlreadyReserved,


        PictureNotAdded,


        ReservationNotFound,
        ReservationNotAdded,
        ReservationNotCanceled

    }
}

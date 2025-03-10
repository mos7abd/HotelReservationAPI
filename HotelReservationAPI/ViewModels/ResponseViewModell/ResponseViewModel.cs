using HotelReservationAPI.Enum;

namespace HotelReservationAPI.ViewModels
{
    public class ResponseViewModel<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public static ResponseViewModel<T> Success(T data, string message = "")
        {
            return new ResponseViewModel<T>
            {
                Data = data,
                IsSuccess = true,
                Message = message,
                ErrorCode = ErrorCode.None,
            };
        }
        public static ResponseViewModel<T> Failure(ErrorCode errorCode, string message)
        {
            return new ResponseViewModel<T>
            {
                Data = default,
                ErrorCode = errorCode,
                IsSuccess = false,
                Message = message,
            };
        }
    }
}

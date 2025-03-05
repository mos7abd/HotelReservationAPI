using HotelReservationAPI.Enum;
using System.Linq.Expressions;

namespace HotelReservationAPI.ResponseModels
{
    public record ResponseViewModel<T>
    {
        public T Data { get; set; } 
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public ErrorCode ErrorCode { get; set; }

        public static ResponseViewModel<T> Success(T date)
        {
            return new ResponseViewModel<T>
            {
                Data = date,
                IsSuccess = true,
                Message = string.Empty,
                ErrorCode = ErrorCode.None
            };
        }
        public static ResponseViewModel<T> Fail(ErrorCode errorCode, string message = "")
        {
            return new ResponseViewModel<T>
            {
                Data = default,
                IsSuccess = true,
                Message = message,
                ErrorCode = errorCode
            };
        }
    }
}

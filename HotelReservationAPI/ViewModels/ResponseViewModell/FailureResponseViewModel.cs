using HotelReservationAPI.Enum;

namespace HotelReservationAPI.ViewModels.ResponseViewModell
{
    public class FailureResponseViewModel<T>:ResponseViewModel<T>
    {
        public FailureResponseViewModel(ErrorCode errorCode,string message="")
        {
            Data = default;
            ErrorCode = errorCode;
            IsSuccess = false;
            Message = message;
        }
    }
}

using HotelReservationAPI.Enum;
using HotelReservationAPI.ViewModels;

namespace HotelReservationAPI.Middlewares
{
    public class GlobalErrorHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (UnauthorizedAccessException)
            {
                ResponseViewModel<bool> response = new ResponseViewModel<bool>
                {
                    ErrorCode = ErrorCode.Unauthorized,
                    Message = "Unauthorized",
                    Data = false,
                    IsSuccess = false
                };
                context.Response.WriteAsJsonAsync(response);
            }
            catch (Exception ex)
            {

                // Log Error
                ResponseViewModel<bool> response = new ResponseViewModel<bool>
                {
                    ErrorCode = ErrorCode.InternalServerError,
                    Message = "Error accour",
                    Data = false,
                    IsSuccess = false
                };
                context.Response.WriteAsJsonAsync(response);


            }





        }
    }
}

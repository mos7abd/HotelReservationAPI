
using Azure;

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
            catch (Exception ex)
            {
                //ResponseViewModel response = new ResponseViewModel { };
                //context.Response.WriteAsJsonAsync(response);
                
                // Log Error
            }
        }
    }
}

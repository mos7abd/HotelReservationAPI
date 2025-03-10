using HotelReservationAPI.Enum;
using HotelReservationAPI.Exceptions;
using HotelReservationAPI.ViewModels;
using System.Text;

namespace HotelReservationAPI.Middlewares
{
    public class ValidationExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidationExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (RequstValidationException exception)
            {
                var validationResult = exception.ValidationResult;
                StringBuilder errorMessage = new StringBuilder();
                foreach (var error in validationResult.Errors)
                {
                    errorMessage.AppendLine($" {error.PropertyName} : {error.ErrorMessage}");
                }


                var result = ResponseViewModel<bool>.Failure(ErrorCode.BadRequest, errorMessage.ToString());

                await context.Response.WriteAsJsonAsync(result);
            }
        }
    }
}

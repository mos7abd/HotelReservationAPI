using FluentValidation.Results;

namespace HotelReservationAPI.Exceptions
{
    public class RequstValidationException : Exception
    {
        public ValidationResult ValidationResult { get; set; }
        public RequstValidationException(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }


    }
}

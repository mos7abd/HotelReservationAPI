using FluentValidation;
using HotelReservationAPI.ViewModels.Reservations;

namespace HotelReservationAPI.Validators.Reservations
{
    public class AddReservationViewModelValidator : AbstractValidator<AddReservationViewModel>
    {
        public AddReservationViewModelValidator()
        {
            RuleFor(R => R.CheckIn).NotEmpty()
                .WithMessage("CheckIn Date is Required");

            RuleFor(R => R.CheckIn)
                .LessThan(R => R.CheckOut)
                .WithMessage("CheckIn Date Must be Less Than CheckOut Date");

            RuleFor(R => R.CheckIn)
                .GreaterThan(DateTime.Now)
                .WithMessage("CheckIn Date Must be Greater Than Current Date");

            RuleFor(R => R.CheckOut)
                .NotEmpty()
                .WithMessage("CheckOut Date is Required");

            RuleFor(R => R.CheckOut)
                .GreaterThan(DateTime.Now)
                .WithMessage("CheckOut Date Must be Greater Than Current Date");

            RuleFor(R => R.CustomerId).GreaterThan(0)
                .NotEmpty()
                .WithMessage("Customer Id is Required");

            RuleFor(R => R.RoomId).GreaterThan(0)
                .NotEmpty()
                .WithMessage("Room Id is Required");
        }
    }
}

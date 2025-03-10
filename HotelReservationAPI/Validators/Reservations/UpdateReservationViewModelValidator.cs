using FluentValidation;
using HotelReservationAPI.ViewModels.Reservations;

namespace HotelReservationAPI.Validators.Reservations
{
    public class UpdateReservationViewModelValidator : AbstractValidator<UpdateReservationViewModel>
    {
        public UpdateReservationViewModelValidator()
        {
            RuleFor(x => x.ID).NotEmpty()
                .WithMessage("ID is required");

            RuleFor(x => x.CheckIn).NotEmpty()
                .WithMessage("CheckIn is required");

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

            RuleFor(x => x.RoomId).NotEmpty()
                .WithMessage("RoomId is required");
        }
    }
}

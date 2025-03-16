using FluentValidation;
using HotelReservationAPI.ViewModels.Users;

namespace HotelReservationAPI.Validators.Users
{
    public class AddUserViewModelValidator : AbstractValidator<AddUserViewModel>
    {
        public AddUserViewModelValidator()
        {
            RuleFor(x => x.FristName).NotEmpty()
                .WithMessage("First name is required");
            RuleFor(x => x.LastName).NotEmpty()
                .WithMessage("Last name is required");

            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(x => x.PhoneNumber)
                    .NotEmpty().WithMessage("Phone number is required")
                    .Matches(@"^0(10|11|12|15)\d{8}$").WithMessage("Invalid phone number format");
            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password is required");
            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .WithMessage("Confirm password is required");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword)
                .WithMessage("Password and confirm password must be same");
        }
    }
}

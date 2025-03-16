using FluentValidation;
using HotelReservationAPI.ViewModels.Users;

namespace HotelReservationAPI.Validators.Users
{
    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty()
                .WithMessage("Email is required");

            RuleFor(x => x.Email).EmailAddress()
                .WithMessage("Invalid email format");

            RuleFor(x => x.Password).NotEmpty()
                .WithMessage("Password is required");
        }
    }
}

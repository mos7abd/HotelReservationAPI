//namespace HotelReservationAPI.Validators.Customers
//{
//    using FluentValidation;
//    using global::HotelReservationAPI.Models;

//    namespace HotelReservationAPI.Models.Validators
//    {
//        public class CustomerValidator : AbstractValidator<Customer>
//        {
//            public CustomerValidator()
//            {
//                RuleFor(customer => customer.)
//                    .NotEmpty().WithMessage("Name is required")
//                    .MaximumLength(50).WithMessage("First name length can't be more than 50.");


//                RuleFor(customer => customer.PhoneNumber)
//                    .NotEmpty().WithMessage("Phone number is required")
//                    .Matches(@"^0(10|11|12|15)\d{8}$").WithMessage("Invalid phone number format");


//            }
//        }
//    }

//}

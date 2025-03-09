using FluentValidation;
using HotelReservationAPI.ViewModels.Room;

namespace HotelReservationAPI.Validators.Rooms
{
    public class AddRoomViewModelValidator : AbstractValidator<AddRoomViewModel>
    {
        public AddRoomViewModelValidator()
        {
            RuleFor(room => room.Type)
               .IsInEnum().WithMessage("Invalid room type");

            RuleFor(room => room.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(room => room.Number)
                .GreaterThan(0).WithMessage("Room number must be greater than 0");

            RuleFor(room => room.Status)
                .IsInEnum().WithMessage("Invalid room status");
        }
    }
}


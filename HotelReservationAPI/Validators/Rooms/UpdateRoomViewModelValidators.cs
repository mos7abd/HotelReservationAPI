using FluentValidation;
using HotelReservationAPI.ViewModels.Room;

namespace HotelReservationAPI.Validators.Rooms
{
    public class UpdateRoomViewModelValidators : AbstractValidator<UpdateRoomViewModel>
    {
        public UpdateRoomViewModelValidators()
        {
            RuleFor(room => room.ID)
                .GreaterThan(0).WithMessage("ID must be greater than 0");

            RuleFor(room => room.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0");

            RuleFor(room => room.Status)
                .IsInEnum().WithMessage("Invalid room status");
        }
    }
}

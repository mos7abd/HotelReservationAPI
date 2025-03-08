using FluentValidation;
using HotelReservationAPI.Dtos.Room;
using HotelReservationAPI.Enum;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Repositoried;
using HotelReservationAPI.Validators.Rooms.HotelReservationAPI.Validators.Rooms;
using System.Text;



namespace HotelReservationAPI.Services
{
    public class RoomService
    {
        GeneralRepository<Room> _roomRepo;
        private IValidator<Room> _validatior;
        public RoomService()
        {
            _roomRepo = new GeneralRepository<Room>();
            _validatior = new RoomValidator();

        }
        public IEnumerable<GetAllRoomDto> GetAllAvailableRooms()
        {
            var room = _roomRepo.Get(r => r.Status == RoomStatus.Available);
            return room.Project<GetAllRoomDto>();
        }
        public GetRoomByIdDto GetRoomById(int id)
        {
            var room = _roomRepo.Get(r => r.ID == id)
                .Project<GetRoomByIdDto>().FirstOrDefault();
            return room;

        }

        public void Add(AddRoomDto addRoomDto)
        {
            var newRoom = addRoomDto.Map<Room>();

            _roomRepo.Add(newRoom);
        }
        public void Update(UpdateRoomDto updateRoomDto)
        {
            var updatedRoom = updateRoomDto.Map<Room>();
            var validationResult = _validatior.Validate(updatedRoom);
            StringBuilder errorMessage = new StringBuilder();
            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    errorMessage.AppendLine($" ,{error.ErrorMessage}");
                }

            }

            _roomRepo.UpdateInclude(updatedRoom,
                nameof(Room.Type), nameof(Room.Price),
                nameof(Room.Number), nameof(Room.Status), nameof(Room.Pictuers));
        }
        public void Delete(int Id)
        {
            _roomRepo.Delete(Id);
        }
    }
}

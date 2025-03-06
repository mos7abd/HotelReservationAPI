using HotelReservationAPI.Dtos.Room;
using HotelReservationAPI.Enum;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Repositoried;


namespace HotelReservationAPI.Services
{
    public class RoomService
    {
        GeneralRepository<Room> _roomRepo;
        public RoomService(GeneralRepository<Room> generalRepository)
        {
            _roomRepo= generalRepository;
        }
        public IEnumerable<GetAllRoomDto> GetAllAvailableRooms()
        {
            var room = _roomRepo.Get(r =>r.Status==RoomStatus.Available);
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
            _roomRepo.SaveChanges();
            // Add room Facilities

            // Add room images

        }
        public void Update(UpdateRoomDto updateRoomDto)
        {
            var updatedRoom = updateRoomDto.Map<Room>();
            _roomRepo.UpdateInclude(updatedRoom,
                nameof(Room.Type), nameof(Room.Price),
                nameof(Room.Number), nameof(Room.Status));//, nameof(Room.Pictuers));
        }
        public void Delete(int Id)
        {
            _roomRepo.Delete(Id);
        }
    }
}

// Add Reservation <= endpoint => Add reser. / Send mail / create payment / add loyality points

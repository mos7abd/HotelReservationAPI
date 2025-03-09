using HotelReservationAPI.Dtos.Room;
using HotelReservationAPI.Enum;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Models;
using HotelReservationAPI.Repositoried;
using Microsoft.EntityFrameworkCore;



namespace HotelReservationAPI.Services
{
    public class RoomService
    {
        GeneralRepository<Room> _roomRepo;
        public RoomService()
        {
            _roomRepo = new GeneralRepository<Room>();

        }
        public IQueryable<GetAllRoomDto> GetAllAvailableRooms()
        {
            var rooms = _roomRepo.Get(r => r.Status == RoomStatus.Available)
                .Project<GetAllRoomDto>();


            return rooms;
        }
        public GetRoomByIdDto GetRoomById(int id)
        {
            var room = _roomRepo.Get(r => r.ID == id)
                .Project<GetRoomByIdDto>().FirstOrDefault();
            return room;

        }
        public async Task<bool> IsRoomExistAsync(int id)
        {
            var IsRoomExist = await _roomRepo.Get(r => r.ID == id).AnyAsync();

            return IsRoomExist;

        }

        public int Add(AddRoomDto addRoomDto)
        {
            var newRoom = addRoomDto.Map<Room>();

            int roomId = _roomRepo.Add(newRoom);

            return roomId;
        }
        public void Update(UpdateRoomDto updateRoomDto)
        {
            var updatedRoom = updateRoomDto.Map<Room>();
            _roomRepo.UpdateInclude(updatedRoom, nameof(Room.Price), nameof(Room.Status));

        }
        public void Delete(int Id)
        {
            _roomRepo.Delete(Id);
        }


    }
}

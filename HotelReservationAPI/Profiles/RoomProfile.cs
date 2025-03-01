using AutoMapper;
using HotelReservationAPI.Dtos.Room;
using HotelReservationAPI.Models;
using HotelReservationAPI.ViewModels.Room;

namespace HotelReservationAPI.Profiles
{
    public class RoomProfile:Profile
    {
        public RoomProfile()
        {
            CreateMap<AddRoomViewModel, AddRoomDto>();
            CreateMap<AddRoomDto, Room>();
            CreateMap<UpdateRoomViewModel,UpdateRoomDto> ();
            CreateMap<UpdateRoomDto, Room>();

            CreateMap<Room, GetAllRoomDto>();
            CreateMap<GetAllRoomDto, GetAllRoomViewModel>();

            CreateMap<Room, GetRoomByIdDto>();
            CreateMap<GetRoomByIdDto, GetRoomByIdViewModel>();
        }
    }
}

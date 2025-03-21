﻿using AutoMapper;
using HotelReservationAPI.Dtos.Rooms;
using HotelReservationAPI.Models;
using HotelReservationAPI.ViewModels.Rooms;

namespace HotelReservationAPI.Profiles
{
    public class RoomProfile : Profile
    {
        public RoomProfile()
        {
            CreateMap<AddRoomViewModel, AddRoomDto>();
            CreateMap<AddRoomViewModel, Room>(); // test
            CreateMap<AddRoomDto, Room>();
            CreateMap<UpdateRoomViewModel, UpdateRoomDto>();
            CreateMap<UpdateRoomDto, Room>();

            CreateMap<Room, GetAllRoomDto>();
            CreateMap<GetAllRoomDto, GetAllRoomViewModel>();

            CreateMap<Room, GetRoomByIdDto>();
            CreateMap<GetRoomByIdDto, GetRoomByIdViewModel>();
        }
    }
}

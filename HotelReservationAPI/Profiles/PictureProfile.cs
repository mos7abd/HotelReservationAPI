using AutoMapper;
using HotelReservationAPI.Dtos.Picture;
using HotelReservationAPI.Dtos.Room;
using HotelReservationAPI.Models;
using HotelReservationAPI.ViewModels.Picture;
using HotelReservationAPI.ViewModels.Room;

namespace HotelReservationAPI.Profiles
{
    public class PictureProfile:Profile
    {
        public PictureProfile()
        {
            CreateMap<AddPictureToRoomViewModel, AddPictureToRoomDto>();
            CreateMap<AddPictureToRoomDto, Picture>();
            CreateMap<UpdatePictureRoomViewModel, UpdatePictureRoomDto>();
            CreateMap<UpdatePictureRoomDto, Picture>();


            CreateMap<Picture, PicturesDto>();
            CreateMap<PicturesDto, PicturesViewModel>();

            CreateMap<Picture, GetAllPicturesRoomDto>();
            CreateMap<GetAllPicturesRoomDto, GetAllRoomPicturesViewModel>();
           
            CreateMap<Picture, GetPictureRoomIdDto>();
            CreateMap<GetPictureRoomIdDto, GetRoomPictureByIdViewModel>();
        }
    }
}

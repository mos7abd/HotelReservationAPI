using AutoMapper;
using HotelReservationAPI.Dtos.Pictures;
using HotelReservationAPI.Models;
using HotelReservationAPI.ViewModels.Pictures;

namespace HotelReservationAPI.Profiles
{
    public class PictureProfile : Profile
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

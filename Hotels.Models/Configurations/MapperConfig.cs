using AutoMapper;
using Hotels.Models.Dtos.Amenity;
using Hotels.Models.Dtos.City;
using Hotels.Models.Dtos.Facility;
using Hotels.Models.Dtos.Hotel;
using Hotels.Models.Dtos.Room;
using Hotels.Models.Dtos.User;
using Hotels.Models.Models;
using Hotels.Models.Models.Auth;
using Hotels.Models.Requests;

namespace Hotels.Models.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<City, CreateCityDto>().ReverseMap();
        CreateMap<City, GetCityDto>().ReverseMap();
        CreateMap<City, CityDto>().ReverseMap();
        CreateMap<City, UpdateCityDto>().ReverseMap();

        CreateMap<Hotel, HotelDto>().ReverseMap();
        CreateMap<Hotel, GetHotelDto>().ReverseMap();
        CreateMap<Hotel, CreateHotelDto>().ReverseMap();
        CreateMap<Hotel, UpdateHotelDto>().ReverseMap();

        CreateMap<Room, RoomDto>().ReverseMap();
        CreateMap<Room, GetRoomDto>().ReverseMap();
        CreateMap<Room, CreateRoomDto>().ReverseMap();
        CreateMap<Room, UpdateRoomDto>().ReverseMap();


        CreateMap<Facility, FacilityDto>().ReverseMap();
        CreateMap<Facility, CreateFacilityDto>().ReverseMap();

        CreateMap<Amenity, AmenityDto>().ReverseMap();
        CreateMap<Amenity, CreateAmenityDto>().ReverseMap();

        CreateMap<UserDto, User>().ReverseMap();

        CreateMap<Booking, BookingRequest>();
        CreateMap<BookingRequest, Booking>();
    }
}

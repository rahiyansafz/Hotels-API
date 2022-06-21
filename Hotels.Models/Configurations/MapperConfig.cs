using AutoMapper;
using Hotels.Models.Dtos.City;
using Hotels.Models.Dtos.Hotel;
using Hotels.Models.Dtos.Room;
using Hotels.Models.Models;

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
    }
}

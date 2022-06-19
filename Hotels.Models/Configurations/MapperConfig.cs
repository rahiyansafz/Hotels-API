using AutoMapper;
using Hotels.Models.Dtos.City;
using Hotels.Models.Models;

namespace Hotels.Models.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<City, CreateCityDto>().ReverseMap();
    }
}

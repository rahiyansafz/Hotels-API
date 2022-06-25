using Hotels.Models.Dtos.Hotel;

namespace Hotels.Models.Dtos.City;

public class GetCityDto : BaseCityDto, IBase
{
    public int Id { get; set; }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Models.Models;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
    public double Rating { get; set; }

    [ForeignKey(nameof(CityId))]
    public int CityId { get; set; }
    public City City { get; set; }
}

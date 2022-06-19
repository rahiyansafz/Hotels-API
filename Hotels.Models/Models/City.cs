namespace Hotels.Models.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Division { get; set; } = string.Empty;

    public virtual IEnumerable<Hotel>? Hotels { get; set; }
}

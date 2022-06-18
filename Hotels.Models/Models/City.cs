namespace Hotels.Models.Models;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Division { get; set; }

    public virtual IList<Hotel>? Hotels { get; set; }
}

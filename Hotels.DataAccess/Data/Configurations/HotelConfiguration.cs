using Hotels.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotels.DataAccess.Data.Configurations;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasData(
            new Hotel
            {
                Id = 1,
                Name = "Le Méridien",
                Address = "79/A Commercial Area Airport Rd, Dhaka-1229",
                Description = "Luxe, modern lodging offering elegant rooms & suites, plus an infinity pool & chic dining.",
                Rating = 4.6,
                RoomCount = 44,
                MinPrice = 4000,
                MaxPrice = 25000,
                Occupancies = 3,
                CityId = 1,
            },
            new Hotel
            {
                Id = 2,
                Name = "Radisson Blu Chattogram Bay View",
                Address = "Shahid Saifuddin Khaled Rd, Chattogram-4000",
                Description = "Polished quarters in a contemporary hotel offering an infinity pool, a spa & 3 restaurants.",
                Rating = 4.6,
                RoomCount = 44,
                MinPrice = 4000,
                MaxPrice = 25000,
                Occupancies = 3,
                CityId = 2,
            },
            new Hotel
            {
                Id = 3,
                Name = "OASIS Hotel",
                Address = "931 Laksham Rd, Cumilla-3501",
                Description = "Laid-back hotel featuring a restaurant & a fitness room, as well as breakfast & parking.",
                Rating = 4.0,
                RoomCount = 44,
                MinPrice = 4000,
                MaxPrice = 25000,
                Occupancies = 3,
                CityId = 3,
            });
    }
}

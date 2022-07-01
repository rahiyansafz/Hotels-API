using Hotels.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotels.DataAccess.Data.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.HasData(
            new Room
            {
                Id = 1,
                Name = "Studio Apartment",
                Type = RoomType.Studio,
                IsAvailable = true,
                IsTrending = true,
                DisplayPrice = "$321",
                DisplayPriceRaw = 321.35,
                MaxOccupancies = 6,
                BedCount = 3,
                BathroomCount = 2,
                IsBooked = false,
                IsFavourite = false,
                ServiceCharge = 15,
                DiscountedPrice = string.Empty,
                HotelId = 1,
            },
            new Room
            {
                Id = 2,
                Name = "Double Deluxe",
                Type = RoomType.DoubleDeluxe,
                IsAvailable = true,
                IsTrending = true,
                DisplayPrice = "$321",
                DisplayPriceRaw = 321.35,
                MaxOccupancies = 6,
                BedCount = 3,
                BathroomCount = 2,
                IsBooked = false,
                IsFavourite = false,
                ServiceCharge = 15,
                DiscountedPrice = string.Empty,
                HotelId = 2
            },
            new Room
            {
                Id = 3,
                Name = "Twin Deluxe",
                Type = RoomType.TwinDeluxe,
                IsAvailable = true,
                IsTrending = true,
                DisplayPrice = "$321",
                DisplayPriceRaw = 321.35,
                MaxOccupancies = 6,
                BedCount = 3,
                BathroomCount = 2,
                IsBooked = false,
                IsFavourite = false,
                ServiceCharge = 15,
                DiscountedPrice = string.Empty,
                HotelId = 3
            });
    }
}

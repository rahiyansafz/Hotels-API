using Hotels.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotels.DataAccess.Data.Configurations;

public class AmenityConfiguration : IEntityTypeConfiguration<Amenity>
{
    public void Configure(EntityTypeBuilder<Amenity> builder)
    {
        builder.HasData(
            new Amenity
            {
                Id = 1,
                KingBedCount = true,
                QueenBedCount = true,
                SofaBedCount = true,
                Dishwasher = true,
                Microwave = true,
                ElectricKettle = true,
                IroningSet = true,
                AirConditioning = true,
                Television = true,
                FreeWifi = true,
                InSuiteLaundry = true,
                StreamingDevice = true,
                StockedKitchen = true,
                MountainOrHillView = true,
                NonSmokingRoom = true,
                RoomId = 1
            },
            new Amenity
            {
                Id = 2,
                KingBedCount = true,
                QueenBedCount = true,
                SofaBedCount = true,
                Dishwasher = true,
                Microwave = true,
                ElectricKettle = true,
                IroningSet = true,
                AirConditioning = true,
                Television = true,
                FreeWifi = true,
                InSuiteLaundry = true,
                StreamingDevice = true,
                StockedKitchen = true,
                MountainOrHillView = true,
                NonSmokingRoom = true,
                RoomId = 2
            },
            new Amenity
            {
                Id = 3,
                KingBedCount = true,
                QueenBedCount = true,
                SofaBedCount = true,
                Dishwasher = true,
                Microwave = true,
                ElectricKettle = true,
                IroningSet = true,
                AirConditioning = true,
                Television = true,
                FreeWifi = true,
                InSuiteLaundry = true,
                StreamingDevice = true,
                StockedKitchen = true,
                MountainOrHillView = true,
                NonSmokingRoom = true,
                RoomId = 3
            });
    }
}

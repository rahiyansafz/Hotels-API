using Hotels.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotels.DataAccess.Data.Configurations;

public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
{
    public void Configure(EntityTypeBuilder<Facility> builder)
    {
        builder.HasData(
            new Facility
            {
                Id = 1,
                ElevatorAccess = true,
                FitnessCenter = true,
                ContactLessCheckIn = true,
                ProfessionalyClean = true,
                Support24by7 = true,
                OutdoorSpace = true,
                SwimmingPool = true,
                FreeParking = true,
                FreeWifi = true,
                LuggageStorage = true,
                IndoorGames = true,
                LoungeAndWorkSpace = true,
                HotelId = 1
            },
            new Facility
            {
                Id = 2,
                ElevatorAccess = true,
                FitnessCenter = true,
                ContactLessCheckIn = true,
                ProfessionalyClean = true,
                Support24by7 = true,
                OutdoorSpace = true,
                SwimmingPool = true,
                FreeParking = true,
                FreeWifi = true,
                LuggageStorage = true,
                IndoorGames = true,
                LoungeAndWorkSpace = true,
                HotelId = 2
            },
            new Facility
            {
                Id = 3,
                ElevatorAccess = true,
                FitnessCenter = true,
                ContactLessCheckIn = true,
                ProfessionalyClean = true,
                Support24by7 = true,
                OutdoorSpace = true,
                SwimmingPool = true,
                FreeParking = true,
                FreeWifi = true,
                LuggageStorage = true,
                IndoorGames = true,
                LoungeAndWorkSpace = true,
                HotelId = 3
            });
    }
}

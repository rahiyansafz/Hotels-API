using Hotels.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotels.DataAccess.Data.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasData(
            new City
            {
                Id = 1,
                Name = "Dhaka",
                Country = "Bangladesh",
                Division = "Dhaka",
                IsFeatured = true,
            },
            new City
            {
                Id = 2,
                Name = "Chittagong",
                Country = "Bangladesh",
                Division = "Chittagong",
                IsFeatured = true,
            },
            new City
            {
                Id = 3,
                Name = "Comilla",
                Country = "Bangladesh",
                Division = "Comilla",
                IsFeatured = true,
            });
    }
}

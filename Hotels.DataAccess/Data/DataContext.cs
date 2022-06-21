using Hotels.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels.DataAccess.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Room> Rooms { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<City>().HasData(
            new City
            {
                Id = 1,
                Name = "Dhaka",
                Country = "Bangladesh",
                Division = "Dhaka",
            },
            new City
            {
                Id = 2,
                Name = "Chittagong",
                Country = "Bangladesh",
                Division = "Chittagong",
            },
            new City
            {
                Id = 3,
                Name = "Comilla",
                Country = "Bangladesh",
                Division = "Comilla",
            });

        modelBuilder.Entity<Hotel>().HasData(
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

        modelBuilder.Entity<Room>().HasData(
            new Room
            {
                Id = 1,
                Name = "Studio Apartment",
                Type = RoomType.Studio,
                IsAvailable = true,
                CheckIn = new DateTime(),
                CheckOut = new DateTime(),
                DisplayPrice = "$321",
                DisplayPriceRaw = 321.35,
                MaxOccupancies = 6,
                BedCount = 3,
                BathroomCount = 2,
                IsBooked = false,
                IsFavourite = false,
                ServiceCharge = 15,
                DiscountedPrice = string.Empty,
                HotelId = 1
            },
            new Room
            {
                Id = 2,
                Name = "Double Deluxe",
                Type = RoomType.DoubleDeluxe,
                IsAvailable = true,
                CheckIn = new DateTime(),
                CheckOut = new DateTime(),
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
                CheckIn = new DateTime(),
                CheckOut = new DateTime(),
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
            }
            );
    }
}
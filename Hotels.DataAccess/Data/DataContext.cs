using Hotels.DataAccess.Data.Configurations;
using Hotels.Models.Models;
using Hotels.Models.Models.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotels.DataAccess.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Amenity> Amenities { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
        modelBuilder.ApplyConfiguration(new HotelConfiguration());
        modelBuilder.ApplyConfiguration(new RoomConfiguration());
        modelBuilder.ApplyConfiguration(new FacilityConfiguration());
        modelBuilder.ApplyConfiguration(new AmenityConfiguration());
    }
}
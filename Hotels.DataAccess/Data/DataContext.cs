﻿using Hotels.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotels.DataAccess.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Hotel> Hotels { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Country>().HasData(
            new Country
            {
                Id = 1,
                Name = "Bangladesh",
                ShortName = "BD"
            },
            new Country
            {
                Id = 2,
                Name = "Australia",
                ShortName = "Aus"
            },
            new Country
            {
                Id = 3,
                Name = "Germany",
                ShortName = "Ger"
            });

        modelBuilder.Entity<Hotel>().HasData(
            new Hotel
            {
                Id = 1,
                Name = "Sandals Resort and Spa",
                Address = "Negril",
                CountryId = 1,
                Rating = 4.5
            },
                new Hotel
                {
                    Id = 2,
                    Name = "Comfort Suites",
                    Address = "George Town",
                    CountryId = 3,
                    Rating = 4.3
                },
                new Hotel
                {
                    Id = 3,
                    Name = "Grand Palldium",
                    Address = "Nassua",
                    CountryId = 2,
                    Rating = 4
                });
    }
}
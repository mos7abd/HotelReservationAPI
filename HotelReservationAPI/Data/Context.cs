﻿using HotelReservationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelReservationAPI.Data
{
    public class Context:DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data source =.;initial catalog = HotelReservationDB; Integrated Security=true; TrustServerCertificate=true")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Room>().HasQueryFilter(r => !r.isDeleted);
        }
    }
}

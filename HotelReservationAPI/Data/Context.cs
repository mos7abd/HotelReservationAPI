using HotelReservationAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HotelReservationAPI.Data
{
    public class Context : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data source =localhost;initial catalog = HotelReservationDB; Integrated Security=true; TrustServerCertificate=true")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Room>().HasQueryFilter(e => !e.IsDeleted);
            modelBuilder.Entity<Reservation>().HasQueryFilter(e => !e.IsDeleted);

        }
    }
}

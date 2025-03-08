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
            optionsBuilder.UseSqlServer(@"Data source =localhost;initial catalog = HotelReservationDB; Trusted_Connection=True;Encrypt=True;TrustServerCertificate=true;")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }
}

using HotelReservationAPI.Models;
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
            optionsBuilder.UseSqlServer(@"Data source =DESKTOP-H0D6UNM\MSSQLSERVER01;initial catalog = HotelReservationDB; Integrated Security=true; TrustServerCertificate=true")
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .LogTo(log => Debug.WriteLine(log), LogLevel.Information)
                .EnableSensitiveDataLogging();
        }
    }
}

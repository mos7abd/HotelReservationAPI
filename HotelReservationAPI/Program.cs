
using AutoMapper;
using HotelReservationAPI.Data;
using HotelReservationAPI.Helper;
using HotelReservationAPI.Middlewares;
using HotelReservationAPI.Models;
using HotelReservationAPI.Profiles;
using HotelReservationAPI.Repositoried;
using HotelReservationAPI.Services;

namespace HotelReservationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<Context>();
            builder.Services.AddScoped<GeneralRepository<Room>>();
            builder.Services.AddScoped<RoomService>();
            builder.Services.AddAutoMapper(typeof(RoomProfile).Assembly);


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<CustomerFakeDataService>();
            builder.Services.AddScoped<GlobalErrorHandlerMiddleware>();
            builder.Services.AddScoped<TransactionMiddleware>();

            var app = builder.Build();
            AutoMaperHelper.Mapper = app.Services.GetService<IMapper>();
            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

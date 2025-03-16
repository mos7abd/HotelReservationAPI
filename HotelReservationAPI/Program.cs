
using AutoMapper;
using HotelReservationAPI.Configurations;
using HotelReservationAPI.Helper;
// ask team: about where should we put Stripe product price Id
using HotelReservationAPI.Middlewares;
using HotelReservationAPI.Models;
using HotelReservationAPI.Profiles;
using HotelReservationAPI.Services;
using Stripe;
using System.Reflection;

namespace HotelReservationAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<RoomService>();
            builder.Services.AddAutoMapper(typeof(RoomProfile).Assembly);


            // Add services to the container.

            builder.Services.RegisterServices()
                .AddAutoMapperConfig()
                .AddAuthenticationConfigration()
                .AddFluentValidation(Assembly.GetExecutingAssembly())
                .AddAuthorization();


            var stripeSettings = builder.Services.Configure<StripeModel>(builder.Configuration.GetSection("Stripe"));
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();


            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName); // Use full name to avoid conflicts
            });

            var app = builder.Build();
            AutoMaperHelper.Mapper = app.Services.GetService<IMapper>();



            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();
            app.UseMiddleware<ValidationExceptionHandlingMiddleware>();


            app.UseAuthentication();
            app.UseAuthorization();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}

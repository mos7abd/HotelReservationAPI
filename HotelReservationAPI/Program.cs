
using AutoMapper;
using HotelReservationAPI.Configurations;
using HotelReservationAPI.Helper;
// ask team: about where should we put Stripe product price Id
using HotelReservationAPI.Middlewares;
using HotelReservationAPI.Models;
using HotelReservationAPI.Profiles;
using HotelReservationAPI.Repositoried;
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
            builder.Services.AddAutoMapper(typeof(RoomProfile).Assembly);


            // Add services to the container.

            builder.Services.RegisterServices()
                .AddAutoMapperConfig()
                .AddFluentValidation(Assembly.GetExecutingAssembly());

            var stripeSettings = builder.Services.Configure<StripeModel>(builder.Configuration.GetSection("Stripe"));
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

            builder.Services.AddScoped<RoomService>();
            builder.Services.AddScoped<GeneralRepository<Models.Customer>>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<StripeService>();
            builder.Services.AddScoped<PriceService>();
            builder.Services.AddScoped<Services.CustomerService>();
            builder.Services.AddScoped<EmailService>();
            builder.Services.AddScoped<MailSettings>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.FullName); // Use full name to avoid conflicts
            });
            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
            var app = builder.Build();
            AutoMaperHelper.Mapper = app.Services.GetService<IMapper>();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ValidationExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

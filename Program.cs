using ClientsApiTest.Models;
using Microsoft.EntityFrameworkCore;
using ClientsApiTest.Models.Repository;

namespace ClientsApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Agrego Contexto
            builder.Services.AddDbContext<AplicationDataBaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
            });

            //Agrego AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            //Agrego Servicio
            builder.Services.AddScoped<IClientRepository, ClientRepository>();

            var app = builder.Build();

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
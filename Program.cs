using ClientsApiTest.Models;
using Microsoft.EntityFrameworkCore;
using ClientsApiTest.Models.Repository;

namespace ClientsApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Crea un nuevo generador de aplicaciones web.
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            // Agrega el servicio de controladores MVC al contenedor.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            // Agrega el servicio de explorador de API Endpoints al contenedor.
            builder.Services.AddEndpointsApiExplorer();

            // Agrega el servicio de generación de Swagger/OpenAPI al contenedor.
            builder.Services.AddSwaggerGen();

            // Agrega el contexto de base de datos de la aplicación.
            // Configura el contexto para utilizar SQL Server como proveedor de base de datos
            // y obtiene la cadena de conexión de la configuración de la aplicación.
            builder.Services.AddDbContext<AplicationDataBaseContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion"));
            });

            // Agrega AutoMapper al contenedor.
            // Configura AutoMapper para buscar perfiles de mapeo en el ensamblado donde se encuentra la clase Program.
            builder.Services.AddAutoMapper(typeof(Program));

            // Agrega el repositorio de clientes como servicio con alcance de tiempo de vida "Scoped".
            // Esto significa que se crea una nueva instancia del repositorio por cada solicitud HTTP.
            builder.Services.AddScoped<IClientRepository, ClientRepository>();

            // Construye la aplicación.
            var app = builder.Build();

            // Configura el pipeline de solicitudes HTTP.
            // Configura Swagger y Swagger UI solo en el entorno de desarrollo.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Redirecciona las solicitudes HTTP a HTTPS si están habilitadas.
            app.UseHttpsRedirection();

            // Configura la autorización para las solicitudes HTTP.
            app.UseAuthorization();

            // Mapea las rutas de los controladores MVC.
            app.MapControllers();

            // Ejecuta la aplicación.
            app.Run();
        }
    }
}
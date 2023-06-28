using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClientsApiTest.Models
{
    /// <summary>
    /// Clase que representa el contexto de la base de datos de la aplicación.
    /// </summary>
    public class AplicationDataBaseContext: DbContext
    {

        public AplicationDataBaseContext(DbContextOptions<AplicationDataBaseContext> options): base(options)
        {

        }

        /// <summary>
        /// Método utilizado para configurar el modelo de datos.
        /// </summary>
        /// <param name="modelBuilder">Constructor de modelos utilizado para configurar el modelo de datos.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar índices únicos para las propiedades Cuit y Email de la entidad Client.
            modelBuilder.Entity<Client>()
                .HasIndex(x => x.Cuit)
                .IsUnique();
            modelBuilder.Entity<Client>()
                .HasIndex(x => x.Email)
                .IsUnique();
        }

        /// <summary>
        /// Conjunto de entidades Client representado en la base de datos.
        /// </summary>
        public DbSet<Client> Clients { get; set; }

    }
}

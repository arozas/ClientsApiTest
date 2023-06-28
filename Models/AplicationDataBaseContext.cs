using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClientsApiTest.Models
{
    //Creo una clase derivaba de DbContext, una clase base nativa de EF Core.
    public class AplicationDataBaseContext: DbContext
    {
        public AplicationDataBaseContext(DbContextOptions<AplicationDataBaseContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasIndex(x => x.Cuit)
                .IsUnique();
            modelBuilder.Entity<Client>()
                .HasIndex(x => x.Email)
                .IsUnique();
        }

        public DbSet<Client> Clients { get; set; }

    }
}

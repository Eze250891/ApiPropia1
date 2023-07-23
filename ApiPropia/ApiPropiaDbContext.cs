using ApiPropia.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ApiPropia
{
    public class ApiPropiaDbContext : DbContext
    {
        public ApiPropiaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); //Aca Aplico las configuracions que estan dentro de la carpeta Configuraciones
        }

        public DbSet<Productos> Productos => Set<Productos>(); //Creo tabla con el nombre ProductoSS
    }
}

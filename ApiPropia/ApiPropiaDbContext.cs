using ApiPropia.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiPropia
{
    public class ApiPropiaDbContext : DbContext
    {
        public ApiPropiaDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Productos> Productos => Set<Productos>(); //Creo tabla con el nombre ProductoSS
    }
}

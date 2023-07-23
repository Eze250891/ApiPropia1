using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPropia.Entidades.Configuraciones
{
    public class ProductosConfiguracion : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.Property(producto => producto.Nombre).HasMaxLength(25);
            builder.Property(producto => producto.Stock).HasPrecision(300);

        }
    }
}
        //Aca configure la tabla Productos 
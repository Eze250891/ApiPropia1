using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiPropia.Entidades.Configuraciones
{
    public class ProductosConfiguracion : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            builder.Property(producto => producto.Nombre).HasMaxLength(25);
            builder.Property(producto => producto.Stock).HasPrecision(5,0);
            
            builder.HasIndex(p => p.Nombre).IsUnique(); //con esto prohivo que desde la db agreguen un producto con un numero repetido
        }
    }
}
        //Aca configure la tabla Productos 
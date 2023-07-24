using System.ComponentModel.DataAnnotations;

namespace ApiPropia.DTOs
{
    public class ProductoCreacionDTO
    {
        [StringLength(maximumLength: 150)]
         public string Nombre { get; set; } = string.Empty;

         public int Stock { get; set; }
        
    }
}

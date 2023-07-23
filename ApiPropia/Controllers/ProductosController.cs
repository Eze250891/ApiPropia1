using ApiPropia.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiPropia.Controllers
{
      [ApiController]
      [Route("api/productos")] 
    public class ProductosController : ControllerBase
    {
        private readonly ApiPropiaDbContext context;

        public ProductosController(ApiPropiaDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post (Productos producto)
        {
            context.Add(producto); //Aca agrego a la tabla producto, el producto ingresado
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> Get()
        {
           
            return await context.Productos.ToListAsync();
        }
 
        
             
        
    }
}

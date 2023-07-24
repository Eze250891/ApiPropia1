using ApiPropia.DTOs;
using ApiPropia.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ApiPropia.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly ApiPropiaDbContext context;
        private readonly IMapper mapper;

        public ProductosController(ApiPropiaDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult> Post(Productos producto)
        {
            context.Add(producto); //Aca agrego a la tabla producto, el producto ingresado
            await context.SaveChangesAsync();
            return Ok();
        }
        //------------------------GET--------------------
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Productos>>> Get()
        {

            return await context.Productos.ToListAsync();
        }

        [HttpGet("nombre")]
        public async Task<ActionResult<IEnumerable<Productos>>> Get(string letra) //filtro por stock
        {
            //contiene
            return await context.Productos.Where(n => n.Nombre.Contains(letra)).ToListAsync();

        }

        [HttpGet("cantidad")]
        public async Task<ActionResult<IEnumerable<Productos>>> Get(int stock) //filtro por stock
        {
            return await context.Productos.Where(s => s.Stock < stock).ToListAsync();

        }
        //-----------------------------PUT----------------
        [HttpPut("{id = int})modificarProducto")]
        public async Task<ActionResult> Put (int id, ProductoCreacionDTO productoCreacionDTO)
        {
            var producto = mapper.Map<Productos>(productoCreacionDTO);
            producto.Id = id;
            context.Update(producto);
            await context.SaveChangesAsync();
            return Ok();
        }
        //-----------------------------DELETE----------------
        [HttpDelete("{id:int}/eliminar")]
        public async Task<ActionResult> Delete (int id)
        {
            var eliminar = await context.Productos.Where(producto => producto.Id == id).ExecuteDeleteAsync();

            if (eliminar == 0)
            {
                return NotFound();

            }
             return NoContent();
        }

        
             
        
    }
}

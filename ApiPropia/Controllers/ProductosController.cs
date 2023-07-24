using ApiPropia.DTOs;
using ApiPropia.Entidades;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        //------------------------POST-------------------
        [HttpPost]
        public async Task<ActionResult> Post(Productos producto, Productos stock)
        {
            var yaExisteElProducto = await context.Productos.AnyAsync(x => x.Nombre == producto.Nombre); //Aca comparo el producto a ingresar con la lista, y si esta no te permite agregarlo

            if (yaExisteElProducto)
            {
                return BadRequest($"Ya Existe este Producto {producto.Nombre}");
            }
           

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

        [HttpGet("OrdenadosAscendiente")]
        public async Task<ActionResult<IEnumerable<Productos>>> GetOrdenAscendiente() //filtro por stock
        {
            return await context.Productos.OrderBy(s => s.Stock).ToListAsync();

        }


        [HttpGet("OrdenadosDescendiente")]
        public async Task<ActionResult<IEnumerable<Productos>>> GetOrden() //filtro por stock
        {
            return await context.Productos.OrderByDescending(s => s.Stock).ToListAsync();

        }

        //-----------------------------PUT----------------
        [HttpPut("{id = int})modificarProducto")]
        public async Task<ActionResult> Put(int id, ProductoCreacionDTO productoCreacionDTO)
        {
            var producto = mapper.Map<Productos>(productoCreacionDTO);
            producto.Id = id;
            context.Update(producto);
            await context.SaveChangesAsync();
            return Ok();
        }
        //-----------------------------DELETE-------------
        [HttpDelete("{id:int}/eliminar")]
        public async Task<ActionResult> Delete(int id)
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

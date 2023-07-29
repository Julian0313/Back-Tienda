using Dominio.Entidades;
using LogicaNegocio.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Herramientas;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductoController : ControllerBase
    {
        private readonly IProductoLogica _productoLogica;
        public ProductoController(IProductoLogica productoLogica)
        {
            _productoLogica = productoLogica;
        }

        [HttpGet]
        [Route("Obtener-Productos")]
        public async Task<IActionResult> ObtenerProductos([FromQuery] ProductoParametros parametros)
        {
            var productos = await _productoLogica.ObtenerProductoLogica(parametros);
            return Ok(productos);
        }

        [HttpGet]
        [Route("Obtener-Producto/{id}")]
        public async Task<IActionResult> ObtenerProductoId(int id)
        {
            return Ok(await _productoLogica.ObtenerProductoIdLogica(id));
        }

        [HttpPost]
        [Route("Crear-Producto")]
        public async Task<IActionResult> CrearProducto(Producto producto)
        {
            await _productoLogica.CrearProductoLogica(producto);
            return Ok(new { message = "Producto creado exitosamente" });
        }

        [HttpPut]
        [Route("Editar-Producto")]
        public async Task<IActionResult> EditarProducto(Producto producto)
        {
            await _productoLogica.EditarProductoLogica(producto);
            return Ok(new { message = "Producto editado exitosamente" });
        }

        [HttpDelete]
        [Route("Eliminar-Producto")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            await _productoLogica.EliminarProductoLogica(id);
            return Ok(new { message = "Producto eliminado exitosamente" });
        }

    }
}
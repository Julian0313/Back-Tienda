using API.Extensiones;
using Dominio.Entidades;
using LogicaNegocio.Interfaz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Herramientas;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    [DynamicRoleAuthorize]     

    public class ProductoController : ControllerBase
    {
        private readonly IProductoLogica _productoLogica;
        public ProductoController(IProductoLogica productoLogica)
        {
            _productoLogica = productoLogica;
        }

        [HttpGet]
        [Route("Obtener-Productos")]
        public async Task<IActionResult> ObtenerProductos([FromQuery] Parametros parametros)
        {
            return Ok(await _productoLogica.ObtenerProductoLogica(parametros));
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
            return Ok(await _productoLogica.CrearProductoLogica(producto));
        }

        [HttpPut]
        [Route("Editar-Producto")]
        public async Task<IActionResult> EditarProducto(Producto producto)
        {           
            return Ok(await _productoLogica.EditarProductoLogica(producto));
        }

        [HttpDelete]
        [Route("Eliminar-Producto")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            return Ok(await _productoLogica.EliminarProductoLogica(id));
        }

    }
}
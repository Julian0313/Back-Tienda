using Logica.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Herramientas;


namespace API.Controllers
{
    public class TiendaController : ControllerBase
    {
        private readonly ITiendaLogica _tiendaLog;
        public TiendaController(ITiendaLogica tiendaLog)
        {
            _tiendaLog = tiendaLog;
        }

        [HttpGet]
        [Route("Obtener-Productos")]
        public async Task<IActionResult> ObtenerProductos([FromQuery] ProductoParametros parametros)
        {
            return Ok(await _tiendaLog.ObtenerProductoLogica(parametros));
        }

        [HttpGet]
        [Route("Obtener-Producto/{id}")]
        public async Task<IActionResult> ObtenerProductoId(int id)
        {
            return Ok(await _tiendaLog.ObtenerProductoIdLogica(id));
        }

    }
}
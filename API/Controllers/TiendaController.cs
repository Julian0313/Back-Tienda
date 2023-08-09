using Logica.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Herramientas;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        private readonly ITiendaLogica _tiendaLog;
        public TiendaController(ITiendaLogica tiendaLog)
        {
            _tiendaLog = tiendaLog;
        }

        [HttpGet]
        [Route("Obtener-Productos")]
        public async Task<IActionResult> ObtenerProductos([FromQuery] Parametros parametros)
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
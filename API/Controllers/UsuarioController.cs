using Logica.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioLogica _usuarioLog;
        public UsuarioController(IUsuarioLogica usuarioLog)
        {
            _usuarioLog = usuarioLog;
        }

        [HttpGet]
        [Route("Obtener-Usuario")]
        public async Task<IActionResult> ObtenerUsuario([FromQuery] string buscar)
        {
            return Ok(await _usuarioLog.ObtenerUsuarioLogica(buscar));
        }
    }
}
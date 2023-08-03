using Logica.Interfaz;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListaDesplegableController : ControllerBase
    {
        private readonly IListaDesplegableLogica _listaLogica;
        public ListaDesplegableController(IListaDesplegableLogica listaLogica)
        {
            _listaLogica = listaLogica;
        }

        [HttpGet]
        [Route("Obtener-Categoria")]
        public async Task<IActionResult> ObtenerCategoria()
        {
            return Ok(await _listaLogica.ObtenerCategoria());
        }

        [HttpGet]
        [Route("Obtener-Estado")]
        public async Task<IActionResult> ObtenerEstado()
        {
            return Ok(await _listaLogica.ObtenerEstado());
        }
    }
}
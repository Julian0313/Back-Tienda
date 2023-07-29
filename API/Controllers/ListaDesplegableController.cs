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
            var categoria = await _listaLogica.ObtenerCategoria();
            return Ok(categoria);
        }

        [HttpGet]
        [Route("Obtener-Estado")]
        public async Task<IActionResult> ObtenerEstado()
        {
            var estado = await _listaLogica.ObtenerEstado();
            return Ok(estado);
        }
    }
}
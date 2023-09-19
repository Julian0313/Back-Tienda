using API.Extensiones;
using Dominio.Entidades;
using Logica.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Herramientas;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [DynamicRoleAuthorize] 
    public class ClienteController : ControllerBase
    {
        private readonly IClienteLogica _clienteLog;
        public ClienteController(IClienteLogica clienteLog)
        {
            _clienteLog = clienteLog;
        }

        [HttpGet]
        [Route("Obtener-Cliente")]
        public async Task<IActionResult> ObtenerCliente([FromQuery] Parametros parametros)
        {
            return Ok(await _clienteLog.ObtenerClienteLogica(parametros));
        }

        [HttpGet]
        [Route("Obtener-Cliente/{id}")]
        public async Task<IActionResult> ObtenerClienteId(int id)
        {
            return Ok(await _clienteLog.ObtenerClienteIdLogica(id));
        }

        [HttpPost]
        [Route("Crear-Cliente")]
        public async Task<IActionResult> CrearCliente(Cliente cliente)
        {
            return Ok(await _clienteLog.CrearClienteLogica(cliente));
        }

        [HttpPut]
        [Route("Editar-Cliente")]
        public async Task<IActionResult> EditarCliente(Cliente cliente)
        {           
            return Ok(await _clienteLog.EditarClienteLogica(cliente));
        }

        [HttpDelete]
        [Route("Eliminar-Cliente")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            return Ok(await _clienteLog.EliminarClienteLogica(id));
        }

        [HttpPost]
        [Route("Registro")]
        public async Task<IActionResult> Registro(SP_Registro registro)
        {
            return Ok(await _clienteLog.RegistroLogica(registro));
        }
    }
}
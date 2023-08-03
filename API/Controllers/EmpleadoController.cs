using Dominio.Entidades;
using Logica.Interfaz;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Herramientas;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoLogica _empleadoLog;
        public EmpleadoController(IEmpleadoLogica empleadoLog)
        {
            _empleadoLog = empleadoLog;
        }
        [HttpGet]
        [Route("Obtener-Empleados")]
        public async Task<IActionResult> ObtenerEmpleados([FromQuery] Parametros parametros)
        {
            return Ok(await _empleadoLog.ObtenerEmpleadoLogica(parametros));
        }

        [HttpGet]
        [Route("Obtener-Empleado/{id}")]
        public async Task<IActionResult> ObtenerEmpleadoId(int id)
        {
            return Ok(await _empleadoLog.ObtenerEmpleadoIdLogica(id));
        }

        [HttpPost]
        [Route("Crear-Empleado")]
        public async Task<IActionResult> CrearEmpleado(Empleado empleado)
        {
            return Ok(await _empleadoLog.CrearEmpleadoLogica(empleado));
        }

        [HttpPut]
        [Route("Editar-Empleado")]
        public async Task<IActionResult> EditarEmpleado(Empleado empleado)
        {           
            return Ok(await _empleadoLog.EditarEmpleadoLogica(empleado));
        }

        [HttpDelete]
        [Route("Eliminar-Empleado")]
        public async Task<IActionResult> EliminarEmpleado(int id)
        {
            return Ok(await _empleadoLog.EliminarEmpleadoLogica(id));
        }
    }
}
using Dominio.Entidades;
using Logica.Herramientas;
using Logica.Interfaz;
using Repositorio.Herramientas;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;

namespace Logica.Implementacion
{
    public class EmpleadoLogica : IEmpleadoLogica
    {
        private readonly IEmpleadoRepositorio _empleadoRepo;
        private readonly IUnidadTrabajo _unidadTrabajo;
        public EmpleadoLogica(IEmpleadoRepositorio empleadoRepo, IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            _empleadoRepo = empleadoRepo;
        }

        public async Task<Respuesta<string>> CrearEmpleadoLogica(Empleado empleado)
        {
            var crearEmpleado = await _empleadoRepo.ObtenerEmpleadoDocumentoAsync(empleado.documento);
            if (crearEmpleado != null)
            {
                return RespuestaErrores.RespuestaError<string>("Ya exsiste un empleado con id : " + empleado.documento);
            }
            await _empleadoRepo.CrearEmpleadoAsync(empleado);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Empleado con id : "+ empleado.documento +" creado correctamente");
        }

        public async Task<Respuesta<string>> EditarEmpleadoLogica(Empleado empleado)
        {
            var editarEmpleado = await _empleadoRepo.ObtenerEmpleadoIdAsync(empleado.idEmpleado);

            if (editarEmpleado == null)
            {
                return RespuestaErrores.RespuestaError<string>("No exsiste un empleado con id : " + empleado.documento);
            }

            await _empleadoRepo.EditarEmpleadoAsync(empleado);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Empleado con id : "+ editarEmpleado.documento +" editado correctamente");
        }

        public async Task<Respuesta<string>> EliminarEmpleadoLogica(int id)
        {
            var eliminarEmpleado = await _empleadoRepo.ObtenerEmpleadoIdAsync(id);

            if (eliminarEmpleado == null)
            {
                return RespuestaErrores.RespuestaError<string>("No exsiste un empleado con id : " + id);
            }

            await _empleadoRepo.EliminarEmpleadoAsync(id);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Empleado con id : "+ eliminarEmpleado.documento +" eliminado correctamente");
        }

        public async Task<Respuesta<EmpleadoRtn>> ObtenerEmpleadoIdLogica(int id)
        {
            var empleadoId = await _empleadoRepo.ObtenerEmpleadoIdAsync(id);
            return empleadoId != null ?
            RespuestaErrores.RespuestaOkay(empleadoId) :
            RespuestaErrores.RespuestaSinRegistros<EmpleadoRtn>("No exsiste un empleado con id : " + id);
        }

        public async Task<Respuesta<Paginacion<EmpleadoRtn>>> ObtenerEmpleadoLogica(Parametros parametros)
        {
            Paginacion<EmpleadoRtn> empleado = await _empleadoRepo.ObtenerEmpleadoAsync(parametros);
            return empleado.Contador > 0 ?
            RespuestaErrores.RespuestaOkay(empleado) :
            RespuestaErrores.RespuestaSinRegistros<Paginacion<EmpleadoRtn>>("No hay registros de empleados");
        }
    }
}
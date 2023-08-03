using Dominio.Entidades;
using Repositorio.Herramientas;


namespace Logica.Interfaz
{
    public interface IEmpleadoLogica
    {
        Task<Respuesta<Paginacion<EmpleadoRtn>>> ObtenerEmpleadoLogica(Parametros parametros);
        Task<Respuesta<EmpleadoRtn>> ObtenerEmpleadoIdLogica(int id);
        Task<Respuesta<string>> CrearEmpleadoLogica(Empleado empleado);
        Task<Respuesta<string>> EditarEmpleadoLogica(Empleado empleado);
        Task<Respuesta<string>> EliminarEmpleadoLogica(int id); 
    }
}
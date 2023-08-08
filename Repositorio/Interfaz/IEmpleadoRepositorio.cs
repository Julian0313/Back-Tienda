using Dominio.Entidades;
using Repositorio.Herramientas;

namespace Repositorio.Interfaz
{
    public interface IEmpleadoRepositorio
    {
        Task<Paginacion<EmpleadoRtn>> ObtenerEmpleadoAsync(Parametros parametros);
        Task<EmpleadoRtn> ObtenerEmpleadoIdAsync(int id);
        Task<EmpleadoRtn> ObtenerEmpleadoDocumentoAsync(string documento);
        Task CrearEmpleadoAsync(Empleado empleado);
        Task EditarEmpleadoAsync(Empleado empleado);
        Task EliminarEmpleadoAsync(int id); 
    }
}
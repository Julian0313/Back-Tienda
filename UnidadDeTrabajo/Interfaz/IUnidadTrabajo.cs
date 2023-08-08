using Repositorio.Interfaz;

namespace UnidadTrabajo.Interfaz
{
    public interface IUnidadTrabajo : IDisposable
    {
        IProductoRepositorio ProductoRepositorio {get; }
        IListaDesplegableRepositorio ListaDesplegableRepositorio {get; }
        ITiendaRepositorio TiendaRepositorio {get; }
        IEmpleadoRepositorio EmpleadoRepositorio {get; }
        IClienteRepositorio ClienteRepositorio {get; }
        Task GuardarCambiosAsync();
    }
}
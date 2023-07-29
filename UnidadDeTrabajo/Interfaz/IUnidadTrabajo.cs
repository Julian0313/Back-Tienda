using Repositorio.Interfaz;

namespace UnidadTrabajo.Interfaz
{
    public interface IUnidadTrabajo : IDisposable
    {
        IProductoRepositorio ProductoRepositorio {get; }
        IListaDesplegableRepositorio ListaDesplegableRepositorio {get; }
        Task GuardarCambiosAsync();
    }
}
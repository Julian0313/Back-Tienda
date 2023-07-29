using Dominio.Entidades;
using Repositorio.Herramientas;

namespace Repositorio.Interfaz
{
    public interface IProductoRepositorio
    {
        Task<Paginacion<ProductoRtn>> ObtenerProductoAsync(ProductoParametros parametros);
        Task<ProductoRtn> ObtenerProductoIdAsync(int id);
        Task CrearProductoAsync(Producto producto);
        Task EditarProductoAsync(Producto producto);
        Task EliminarProductoAsync(int id);
    }
}

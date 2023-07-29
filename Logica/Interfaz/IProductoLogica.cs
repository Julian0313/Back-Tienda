using Dominio.Entidades;
using Repositorio.Herramientas;

namespace LogicaNegocio.Interfaz
{
    public interface IProductoLogica
    {
        Task<Paginacion<ProductoRtn>> ObtenerProductoLogica(ProductoParametros parametros);
        Task<ProductoRtn> ObtenerProductoIdLogica(int id);
        Task<string> CrearProductoLogica(Producto producto);
        Task EditarProductoLogica(Producto producto);
        Task EliminarProductoLogica(int id);
    }
}
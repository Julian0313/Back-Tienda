using Dominio.Entidades;
using Repositorio.Herramientas;

namespace LogicaNegocio.Interfaz
{
    public interface IProductoLogica
    {
        Task<Respuesta<Paginacion<ProductoRtn>>> ObtenerProductoLogica(Parametros parametros);
        Task<Respuesta<ProductoRtn>> ObtenerProductoIdLogica(int id);
        Task<Respuesta<string>> CrearProductoLogica(Producto producto);
        Task<Respuesta<string>> EditarProductoLogica(Producto producto);
        Task<Respuesta<string>> EliminarProductoLogica(int id);
    }
}
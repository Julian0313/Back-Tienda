using Dominio.Entidades;
using Repositorio.Herramientas;

namespace Repositorio.Interfaz
{
    public interface ITiendaRepositorio
    {
        Task<Paginacion<ProductoRtn>> ObtenerProductoAsync(ProductoParametros parametros);
        Task<ProductoRtn> ObtenerProductoIdAsync(int id);
    }
}
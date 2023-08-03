using Dominio.Entidades;
using Repositorio.Herramientas;

namespace Logica.Interfaz
{
    public interface ITiendaLogica
    {
        Task<Respuesta<Paginacion<ProductoRtn>>> ObtenerProductoLogica(ProductoParametros parametros);
        Task<Respuesta<ProductoRtn>> ObtenerProductoIdLogica(int id);
    }
}
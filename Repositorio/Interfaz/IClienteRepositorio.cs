using Dominio.Entidades;
using Repositorio.Herramientas;

namespace Repositorio.Interfaz
{
    public interface IClienteRepositorio
    {
        Task<Paginacion<ClienteRtn>> ObtenerClienteAsync(Parametros parametros);
        Task<ClienteRtn> ObtenerClienteIdAsync(int id);
        Task CrearClienteAsync(Cliente cliente);
        Task EditarClienteAsync(Cliente cliente);
        Task EliminarClienteAsync(int id);
    }
}
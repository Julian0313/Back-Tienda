using Dominio.Entidades;

namespace Repositorio.Interfaz
{
    public interface IListaDesplegableRepositorio
    {
        Task<IReadOnlyList<Categoria>> ObtenerCategoriaAsync();
        Task<IReadOnlyList<Estado>> ObtenerEstadoAsync();
        Task<IReadOnlyList<Cargo>> ObtenerCargoAsync();
    }
}
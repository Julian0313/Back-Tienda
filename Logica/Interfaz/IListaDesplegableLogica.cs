using Dominio.Entidades;

namespace Logica.Interfaz
{
    public interface IListaDesplegableLogica
    {
        Task<Respuesta<IReadOnlyList<Categoria>>> ObtenerCategoriaLogica();
        Task<Respuesta<IReadOnlyList<Estado>>> ObtenerEstadoLogica();
        Task<Respuesta<IReadOnlyList<Cargo>>> ObtenerCargoLogica();
    }
}
using Dominio.Entidades;

namespace Logica.Interfaz
{
    public interface IListaDesplegableLogica
    {
        Task<IReadOnlyList<Categoria>> ObtenerCategoria();
        Task<IReadOnlyList<Estado>> ObtenerEstado();
    }
}
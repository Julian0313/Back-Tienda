using Dominio.Entidades;

namespace Logica.Interfaz
{
    public interface IListaDesplegableLogica
    {
        Task<Respuesta<IReadOnlyList<Categoria>>> ObtenerCategoria();
        Task<Respuesta<IReadOnlyList<Estado>>> ObtenerEstado();
    }
}
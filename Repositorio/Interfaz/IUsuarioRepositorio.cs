using Dominio.Entidades;

namespace Repositorio.Interfaz
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<UsuarioRtn>> ObtenerUsuarioAsync(string buscar);
        Task EditarUsuarioAsync(Usuario usuario);
    }
}
using Dominio.Entidades;

namespace Repositorio.Interfaz
{
    public interface IUsuarioRepositorio
    {
        Task<UsuarioRtn> ObtenerUsuarioAsync(string buscar);
        Task EditarUsuarioAsync(Usuario usuario);
    }
}
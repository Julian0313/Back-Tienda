using Dominio.Entidades;
using Repositorio.Herramientas;


namespace Logica.Interfaz
{
    public interface IUsuarioLogica
    {
        Task<Respuesta<UsuarioRtn>> ObtenerUsuarioLogica(string buscar);
        Task<Respuesta<string>> EditarUsuarioLogica(Usuario usuario);
        Task<bool> ValidarUsuarioLogica(Usuario usuario);
    }
}
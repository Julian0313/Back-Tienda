using Dominio.Entidades;
using Repositorio.Herramientas;


namespace Logica.Interfaz
{
    public interface IUsuarioLogica
    {
        Task<Respuesta<IEnumerable<UsuarioRtn>>> ObtenerUsuarioLogica(string buscar);
        Task<Respuesta<string>> EditarUsuarioLogica(Usuario usuario);
    }
}
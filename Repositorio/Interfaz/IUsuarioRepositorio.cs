using Dominio.Entidades;
using Repositorio.Herramientas;


namespace Repositorio.Interfaz
{
    public interface IUsuarioRepositorio
    {
        Task<IEnumerable<Usuario>> ObtenerUsuarioAsync(Parametros parametros);
    }
}
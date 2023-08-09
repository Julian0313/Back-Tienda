using Dominio.Entidades;
using Repositorio.Herramientas;


namespace Repositorio.Interfaz
{
    public interface IUsuarioRepositorio
    {
        Task<Paginacion<UsuarioRtn>> ObtenerUsuarioAsync(Parametros parametros);
    }
}
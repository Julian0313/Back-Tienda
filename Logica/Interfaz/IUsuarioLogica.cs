using Dominio.Entidades;
using Repositorio.Herramientas;


namespace Logica.Interfaz
{
    public interface IUsuarioLogica
    {
         Task<Respuesta<Paginacion<UsuarioRtn>>> ObtenerUsuarioLogica(Parametros parametros);
    }
}
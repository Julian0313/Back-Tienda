using Dominio.Entidades;
using Repositorio.Herramientas;


namespace Logica.Interfaz
{
    public interface IUsuarioLogica
    {
         Task<Respuesta<IEnumerable<Usuario>>> ObtenerUsuarioLogica(Parametros parametros);
    }
}
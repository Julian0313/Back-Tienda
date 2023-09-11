using Dominio.Entidades;
using Repositorio.Herramientas;

namespace Logica.Interfaz
{
    public interface IClienteLogica
    {
        Task<Respuesta<Paginacion<ClienteRtn>>> ObtenerClienteLogica(Parametros parametros);
        Task<Respuesta<ClienteRtn>> ObtenerClienteIdLogica(int id);
        Task<Respuesta<string>> CrearClienteLogica(Cliente cliente);
        Task<Respuesta<string>> RegistroLogica(SP_Registro registro);
        Task<Respuesta<string>> EditarClienteLogica(Cliente cliente);
        Task<Respuesta<string>> EliminarClienteLogica(int id);

    }
}
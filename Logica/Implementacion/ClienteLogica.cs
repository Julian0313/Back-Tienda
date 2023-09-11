using Dominio.Entidades;
using Logica.Herramientas;
using Logica.Interfaz;
using Repositorio.Herramientas;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;

namespace Logica.Implementacion
{

    public class ClienteLogica : IClienteLogica
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IClienteRepositorio _clienteRepo;
        public ClienteLogica(IClienteRepositorio clienteRepo, IUnidadTrabajo unidadTrabajo)
        {
            _clienteRepo = clienteRepo;
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<Respuesta<string>> CrearClienteLogica(Cliente cliente)
        {
            var crearCliente = await _clienteRepo.ObtenerClienteCorreoAsync(cliente.email);
            if (crearCliente != null)
            {
                return RespuestaErrores.RespuestaError<string>("Esta direccion de correo ya cuenta con una cuenta");
            }
            await _clienteRepo.CrearClienteAsync(cliente);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Cliente con id: " + cliente.identificacion + " creado correctamente");

        }

        public async Task<Respuesta<string>> EditarClienteLogica(Cliente cliente)
        {
            var editarCliente = await _clienteRepo.ObtenerClienteIdAsync(cliente.idCliente);

            if (editarCliente == null)
            {
                return RespuestaErrores.RespuestaError<string>("No exsiste un cliente con id : " + cliente.idCliente);
            }

            await _clienteRepo.EditarClienteAsync(cliente);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Cliente con id: "+ cliente.identificacion + " editado correctamente");
        }

        public async Task<Respuesta<string>> EliminarClienteLogica(int id)
        {
            var eliminarCliente = await _clienteRepo.ObtenerClienteIdAsync(id);

            if (eliminarCliente == null)
            {
                return RespuestaErrores.RespuestaError<string>("No exsiste un cliente con id : " + id);
            }

            await _clienteRepo.EliminarClienteAsync(id);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Cliente con id: "+ id + " editado correctamente");
        }

        public async Task<Respuesta<ClienteRtn>> ObtenerClienteIdLogica(int id)
        {
            var clienteId = await _clienteRepo.ObtenerClienteIdAsync(id);
            return clienteId != null ?
            RespuestaErrores.RespuestaOkay(clienteId) :
            RespuestaErrores.RespuestaSinRegistros<ClienteRtn>("No exsiste un cliente con id : " + id);
        }

        public async Task<Respuesta<Paginacion<ClienteRtn>>> ObtenerClienteLogica(Parametros parametros)
        {
            Paginacion<ClienteRtn> cliente = await _clienteRepo.ObtenerClienteAsync(parametros);
            return cliente.Contador > 0 ?
            RespuestaErrores.RespuestaOkay(cliente) :
            RespuestaErrores.RespuestaSinRegistros<Paginacion<ClienteRtn>>("No hay registros de clientes");
        }

        public async Task<Respuesta<string>> RegistroLogica(SP_Registro registro)
        {
             var registroCliente = await _clienteRepo.ObtenerClienteCorreoAsync(registro.email);
            if (registroCliente != null)
            {
                return RespuestaErrores.RespuestaError<string>("Esta direccion de correo se encuentra registrada");
            }
            await _clienteRepo.Registro(registro);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Usuario: " + registro.email + " fue creado con exito");
        }
    }

}
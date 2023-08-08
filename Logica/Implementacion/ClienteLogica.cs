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
            try
            {
                var crearCliente = await _clienteRepo.ObtenerClienteCorreoAsync(cliente.email);
                if (crearCliente != null)
                {
                    return RespuestaErrores.RespuestaError<string>("Esta direccion de correo ya cuenta con una cuenta");
                }
                await _clienteRepo.CrearClienteAsync(cliente);
                await _unidadTrabajo.GuardarCambiosAsync();

                return RespuestaErrores.RespuestaOkay<string>("Cliente con id: "+ crearCliente.email +"creado correctamente");
            }
            catch(Exception ex)
            {
                return RespuestaErrores.RespuestaError<string>("Error al crear el producto: " + ex.Message);
            }
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

                return RespuestaErrores.RespuestaOkay<string>("Cliente editado correctamente id : " + cliente.idCliente);
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

                return RespuestaErrores.RespuestaOkay<string>("Cliente eliminado correctamente id : " + id);
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
        }

    }
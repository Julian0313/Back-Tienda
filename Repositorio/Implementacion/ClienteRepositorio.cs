using AutoMapper;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Herramientas;
using Repositorio.Interfaz;

namespace Repositorio.Implementacion
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly TiendaContexto _contexto;
        private readonly IMapper _mapper;
        public ClienteRepositorio(TiendaContexto contexto, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = contexto;
        }

        public async Task CrearClienteAsync(Cliente cliente)
        {
            cliente.fechaCreacion = DateTime.Now;
            cliente.fechaModificacion = null;
            cliente.fkIdEstado = 1;
            _contexto.Cliente.Add(cliente);
            await _contexto.SaveChangesAsync();
        }

        public async Task EditarClienteAsync(Cliente cliente)
        {
            var editarCliente = await _contexto.Cliente.FindAsync(cliente.idCliente);

            editarCliente.identificacion = cliente.identificacion;
            editarCliente.identificacion = cliente.identificacion;
            editarCliente.primerNombre = cliente.primerNombre;
            editarCliente.segundoNombre = cliente.segundoNombre;
            editarCliente.primerApellido = cliente.primerApellido;
            editarCliente.segundoApellido = cliente.segundoApellido;
            editarCliente.email = cliente.email;
            editarCliente.direccion = cliente.direccion;
            editarCliente.celular = cliente.celular;
            editarCliente.fechaModificacion = DateTime.Now;
            editarCliente.fkIdEstado = cliente.fkIdEstado;
            editarCliente.fkIdUsuario = cliente.fkIdUsuario;

            await _contexto.SaveChangesAsync();
        }

        public async Task EliminarClienteAsync(int id)
        {
            var eliminarCliente = await _contexto.Cliente.FindAsync(id);

            eliminarCliente.fkIdEstado = 0;
            eliminarCliente.fechaModificacion = DateTime.Now;

            await _contexto.SaveChangesAsync();
        }

        public async Task<Paginacion<ClienteRtn>> ObtenerClienteAsync(Parametros parametros)
        {
            var clientes = _contexto.Cliente.AsQueryable();

            if (!string.IsNullOrEmpty(parametros.Buscar))
            {
                clientes = clientes.Where(p => p.identificacion.ToLower().Contains(parametros.Buscar) | p.email.ToLower().Contains(parametros.Buscar));
            }

            var contador = await clientes.CountAsync();

            var clientePag = await clientes
                .Include(e => e.Estado)
                .Include(u => u.Usuario)
                .Skip((parametros.PageIndex - 1) * parametros.PageSize)
                .Take(parametros.PageSize)
                .ToListAsync();

            var paginacion = new Paginacion<ClienteRtn>(
                parametros.PageIndex,
                parametros.PageSize,
                contador,
                _mapper.Map<IReadOnlyList<ClienteRtn>>(clientePag)
            );

            return paginacion;
        }

        public async Task<ClienteRtn> ObtenerClienteCorreoAsync(string correo)
        {
            var cliente = await _contexto.Cliente
                  .Include(e => e.Estado)
                  .Include(u => u.Usuario)
                  .FirstOrDefaultAsync(x => x.email == correo);

            return _mapper.Map<ClienteRtn>(cliente);
        }

        public async Task<ClienteRtn> ObtenerClienteIdAsync(int id)
        {
            var cliente = await _contexto.Cliente
                  .Include(e => e.Estado)
                  .Include(u => u.Usuario)
                  .FirstOrDefaultAsync(x => x.idCliente == id);

            return _mapper.Map<ClienteRtn>(cliente);
        }
    }
}

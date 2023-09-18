using System.Data;
using AutoMapper;
using Dominio.Entidades;
using Microsoft.Data.SqlClient;
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
            var usuario = new Usuario
            {
                usuario = cliente.email,
                contrasena = BCrypt.Net.BCrypt.HashPassword(cliente.identificacion),
                fkIdEstado = 1,
                fechaCreacion = DateTime.Now,
                fechaModificacion = null,
                fkIdRol = 2
            };
            _contexto.Usuario.Add(usuario);
            await _contexto.SaveChangesAsync();

            int idUsuarioGenerado = await _contexto.Usuario.MaxAsync(u => u.idUsuario);

            var crearCliente = new Cliente
            {
                idCliente = 0,
                identificacion = cliente.identificacion,
                primerNombre = cliente.primerNombre,
                segundoNombre = cliente.segundoNombre,
                primerApellido = cliente.primerApellido,
                segundoApellido = cliente.segundoApellido,
                email = cliente.email,
                direccion = cliente.direccion,
                celular = cliente.celular,
                fechaCreacion = DateTime.Now,
                fechaModificacion = null,
                fkIdEstado = 1,
                fkIdUsuario = idUsuarioGenerado
            };

            _contexto.Cliente.Add(crearCliente);
            await _contexto.SaveChangesAsync();
        }

        public async Task EditarClienteAsync(Cliente cliente)
        {
            var editarCliente = await _contexto.Cliente.FindAsync(cliente.idCliente);
            var editarUsuario = await _contexto.Usuario.FirstOrDefaultAsync(u => u.usuario == editarCliente.email);

            if (cliente.email == editarCliente.email & cliente.fkIdEstado == editarCliente.fkIdEstado)
            {
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
            else
            {
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

                editarUsuario.usuario = cliente.email;
                editarUsuario.fechaModificacion = DateTime.Now;
                editarUsuario.fkIdEstado = editarCliente.fkIdEstado;

                await _contexto.SaveChangesAsync();
            }
        }

        public async Task EliminarClienteAsync(int id)
        {
            var eliminarCliente = await _contexto.Cliente.FindAsync(id);
            var eliminarUsuario = await _contexto.Usuario.FirstOrDefaultAsync(u => u.usuario == eliminarCliente.email);

            eliminarCliente.fkIdEstado = 0;
            eliminarCliente.fechaModificacion = DateTime.Now;

            eliminarUsuario.fkIdEstado = 0;
            eliminarUsuario.fechaModificacion = DateTime.Now;

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

        public async Task Registro(SP_Registro registro)
        {
            var sql = "EXEC sp_registro @identificacion, @primerNombre, @segundoNombre, @primerApellido, @segundoApellido, @email, @direccion, @celular, @contrasena, @rol";
            
            var contrasena = BCrypt.Net.BCrypt.HashPassword(registro.contrasena);

            await _contexto.Database.ExecuteSqlRawAsync(sql,
            
            new SqlParameter("@identificacion", registro.identificacion),
            new SqlParameter("@primerNombre", registro.primerNombre),
            new SqlParameter("@segundoNombre", registro.segundoNombre),
            new SqlParameter("@primerApellido", registro.primerApellido),
            new SqlParameter("@segundoApellido", registro.segundoApellido),
            new SqlParameter("@email", registro.email),
            new SqlParameter("@direccion", registro.direccion),
            new SqlParameter("@celular", registro.celular),
            new SqlParameter("@contrasena", contrasena),
            new SqlParameter("@rol", registro.fkIdRol));
        }
    }
}
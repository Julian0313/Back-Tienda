using AutoMapper;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Herramientas;
using Repositorio.Interfaz;

namespace Repositorio.Implementacion
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly TiendaContexto _contexto;
        private readonly IMapper _mapper;
        public UsuarioRepositorio(TiendaContexto contexto, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = contexto;
        }

        public async Task EditarUsuarioAsync(Usuario usuario)
        {
            var editarUsuario = await _contexto.Usuario.FirstOrDefaultAsync(u => u.usuario == usuario.usuario);

            editarUsuario.contrasena = usuario.contrasena;
            editarUsuario.fechaModificacion = DateTime.Now;

            await _contexto.SaveChangesAsync();
        }

        public async Task<UsuarioRtn> ObtenerUsuarioAsync(string buscar)
        {
            var usuario = await _contexto.Usuario
                .Include(e => e.Estado)
                .FirstOrDefaultAsync(p => p.usuario == buscar);

            return _mapper.Map<UsuarioRtn>(usuario);

        }
    }
}
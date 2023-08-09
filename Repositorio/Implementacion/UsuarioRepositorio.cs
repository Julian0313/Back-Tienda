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

        public async Task<IEnumerable<UsuarioRtn>> ObtenerUsuarioAsync(string buscar)
        {
            var usuarioBuscar = _contexto.Usuario.AsQueryable();

            if (!string.IsNullOrEmpty(buscar))
            {
                usuarioBuscar = usuarioBuscar.Where(p => p.usuario.ToLower().Contains(buscar));
            }
            
            var contador = await usuarioBuscar.CountAsync();

            var usuario = await usuarioBuscar.Include(e => e.Estado).ToListAsync();

            return _mapper.Map<IReadOnlyList<UsuarioRtn>>(usuario);
        }
    }
}
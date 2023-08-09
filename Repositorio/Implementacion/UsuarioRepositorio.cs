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

        public async Task<Paginacion<UsuarioRtn>> ObtenerUsuarioAsync(Parametros parametros)
        {
            var usuario = _contexto.Usuario.AsQueryable();

            if (!string.IsNullOrEmpty(parametros.Buscar))
            {
                usuario = usuario.Where(p => p.usuario.ToLower().Contains(parametros.Buscar));
            }
            
            var contador = await usuario.CountAsync();

            var usuarioPag = await usuario
                .Include(e => e.Estado)
                .Skip((parametros.PageIndex - 1) * parametros.PageSize)
                .Take(parametros.PageSize)                
                .ToListAsync();

            var paginacion = new Paginacion<UsuarioRtn>(
                parametros.PageIndex,
                parametros.PageSize,
                contador,
                _mapper.Map<IReadOnlyList<UsuarioRtn>>(usuarioPag)
            );

            return paginacion;
        }
    }
}
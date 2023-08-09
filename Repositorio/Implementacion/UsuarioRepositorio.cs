using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Herramientas;
using Repositorio.Interfaz;

namespace Repositorio.Implementacion
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly TiendaContexto _contexto;
        public UsuarioRepositorio(TiendaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Usuario>> ObtenerUsuarioAsync(Parametros parametros)
        {
            var usuario = _contexto.Usuario.AsQueryable();

            if (!string.IsNullOrEmpty(parametros.Buscar))
            {
                usuario = usuario.Where(p => p.usuario.ToLower().Contains(parametros.Buscar));
            }

            return usuario;
        }
    }
}
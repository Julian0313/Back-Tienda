using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Interfaz;

namespace Repositorio.Implementacion
{
    public class ListaDesplegableRepositorio : IListaDesplegableRepositorio
    {
        private readonly TiendaContexto _contexto;
        public ListaDesplegableRepositorio(TiendaContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<IReadOnlyList<Categoria>> ObtenerCategoriaAsync()
        {
            return await _contexto.Categoria.ToListAsync();
        }

        public async Task<IReadOnlyList<Estado>> ObtenerEstadoAsync()
        {
            return await _contexto.Estado.ToListAsync();
        }
    }
}
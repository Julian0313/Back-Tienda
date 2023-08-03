using AutoMapper;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Herramientas;
using Repositorio.Interfaz;

namespace Repositorio.Implementacion
{
    public class TiendaRepositorio : ITiendaRepositorio
    {
        private readonly TiendaContexto _contexto;
        private readonly IMapper _mapper;
        public TiendaRepositorio(TiendaContexto contexto, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = contexto;
        }

        public async Task<Paginacion<ProductoRtn>> ObtenerProductoAsync(ProductoParametros parametros)
        {
             var productos = _contexto.Producto.AsQueryable().Where(e => e.fkIdEstado == 1);

            if (!string.IsNullOrEmpty(parametros.Buscar))
            {
                productos = productos.Where(p => p.nombre.ToLower().Contains(parametros.Buscar));
            }

            var contador = await productos.CountAsync();

            var productosPag = await productos
                .Include(e => e.Estado)
                .Include(c => c.Categoria)
                .Skip((parametros.PageIndex - 1) * parametros.PageSize)
                .Take(parametros.PageSize)                
                .ToListAsync();

            var paginacion = new Paginacion<ProductoRtn>(
                parametros.PageIndex,
                parametros.PageSize,
                contador,
                _mapper.Map<IReadOnlyList<ProductoRtn>>(productosPag)
            );

            return paginacion;
        }

        public async Task<ProductoRtn> ObtenerProductoIdAsync(int id)
        {
            var producto = await _contexto.Producto
                .Include(e => e.Estado)
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(x => x.idProducto == id);

            return _mapper.Map<ProductoRtn>(producto);
        }
    }
}
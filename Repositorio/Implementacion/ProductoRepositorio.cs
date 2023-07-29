using AutoMapper;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Herramientas;
using Repositorio.Interfaz;

namespace Repositorio.Implementacion
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly TiendaContexto _contexto;
        private readonly IMapper _mapper;

        public ProductoRepositorio(TiendaContexto contexto, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = contexto;
        }

        public async Task CrearProductoAsync(Producto producto)
        {
            producto.fechaCreacion = DateTime.Now;
            producto.fechaModificacion = null;
            producto.fkIdEstado = 1;
            _contexto.Producto.Add(producto);
            await _contexto.SaveChangesAsync();

        }

        public async Task EliminarProductoAsync(int id)
        {
            var eliminarProducto = await _contexto.Producto.FindAsync(id);

            eliminarProducto.fkIdEstado = 0;
            eliminarProducto.fechaModificacion = DateTime.Now;

            await _contexto.SaveChangesAsync();
        }

        public async Task EditarProductoAsync(Producto producto)
        {
            var editarProducto = await _contexto.Producto.FindAsync(producto.idProducto);

            editarProducto.nombre = producto.nombre;
            editarProducto.descripcion = producto.descripcion;
            editarProducto.precio = producto.precio;
            editarProducto.cantidad = producto.cantidad;
            editarProducto.imagenUrl = producto.imagenUrl;
            editarProducto.fechaModificacion = DateTime.Now;
            editarProducto.fkIdEstado = producto.fkIdEstado;
            editarProducto.fkIdCategoria = producto.fkIdCategoria;

            await _contexto.SaveChangesAsync();

        }

        public async Task<Paginacion<ProductoRtn>> ObtenerProductoAsync(ProductoParametros parametros)
        {
            var productos = _contexto.Producto.AsQueryable();

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

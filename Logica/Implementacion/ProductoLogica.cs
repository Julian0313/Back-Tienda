using Dominio.Entidades;
using LogicaNegocio.Interfaz;
using Repositorio.Herramientas;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;

namespace LogicaNegocio.Implementacion
{
    public class ProductoLogica : IProductoLogica
    {
        private readonly IProductoRepositorio _productoRepo;
        private readonly IUnidadTrabajo _unidadTrabajo;

        public ProductoLogica(IProductoRepositorio productoRepo, IUnidadTrabajo unidadTrabajo)
        {
            _productoRepo = productoRepo;
            _unidadTrabajo = unidadTrabajo;
        }

        public async Task<string> CrearProductoLogica(Producto producto)
        {
            try
            {
                await _productoRepo.CrearProductoAsync(producto);
                await _unidadTrabajo.GuardarCambiosAsync();

                return "Producto creado correctamente";
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el producto.", ex);
            }
        }

        public async Task EditarProductoLogica(Producto producto)
        {
            try
            {
                var editarProducto = await _productoRepo.ObtenerProductoIdAsync(producto.idProducto);

                if (editarProducto == null)
                {
                    throw new InvalidOperationException("No se encontró el producto con el ID proporcionado");
                }

                await _productoRepo.EditarProductoAsync(producto);
                await _unidadTrabajo.GuardarCambiosAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el producto.", ex);
            }
        }

        public async Task EliminarProductoLogica(int id)
        {
             try
            {
                var eliminarProducto = await _productoRepo.ObtenerProductoIdAsync(id);

                if (eliminarProducto == null)
                {
                    throw new InvalidOperationException("No se encontró el producto con el ID proporcionado");
                }

                await _productoRepo.EliminarProductoAsync(id);
                await _unidadTrabajo.GuardarCambiosAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el producto.", ex);
            }
        }

        public async Task<Paginacion<ProductoRtn>> ObtenerProductoLogica(ProductoParametros parametros)
        {
            try
            {
                return await _productoRepo.ObtenerProductoAsync(parametros);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los productos.", ex);
            }
        }

        public async Task<ProductoRtn> ObtenerProductoIdLogica(int id)
        {
            try
            {
                return await _productoRepo.ObtenerProductoIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el producto", ex);
            }
        }
    }
}
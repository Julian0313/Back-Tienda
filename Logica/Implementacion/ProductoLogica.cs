using Dominio.Entidades;
using Logica.Herramientas;
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

        public async Task<Respuesta<string>> CrearProductoLogica(Producto producto)
        {
            var crearProducto = await _productoRepo.ObtenerProductoIdAsync(producto.idProducto);
            if (crearProducto != null)
            {
                return RespuestaErrores.RespuestaError<string>("Ya exsiste un producto con id : " + producto.idProducto);
            }
            await _productoRepo.CrearProductoAsync(producto);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Producto creado correctamente id : " + producto.idProducto);

        }

        public async Task<Respuesta<string>> EditarProductoLogica(Producto producto)
        {

            var editarProducto = await _productoRepo.ObtenerProductoIdAsync(producto.idProducto);

            if (editarProducto == null)
            {
                return RespuestaErrores.RespuestaError<string>("No exsiste un producto con id : " + producto.idProducto);
            }

            await _productoRepo.EditarProductoAsync(producto);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Producto editado correctamente id : " + producto.idProducto);

        }

        public async Task<Respuesta<string>> EliminarProductoLogica(int id)
        {
            var eliminarProducto = await _productoRepo.ObtenerProductoIdAsync(id);

            if (eliminarProducto == null)
            {
                return RespuestaErrores.RespuestaError<string>("No exsiste un producto con id : " + id);
            }

            await _productoRepo.EliminarProductoAsync(id);
            await _unidadTrabajo.GuardarCambiosAsync();

            return RespuestaErrores.RespuestaOkay<string>("Producto eliminado correctamente id : " + id);
        }

        public async Task<Respuesta<Paginacion<ProductoRtn>>> ObtenerProductoLogica(Parametros parametros)
        {
            Paginacion<ProductoRtn> producto = await _productoRepo.ObtenerProductoAsync(parametros);
            return producto != null ?
            RespuestaErrores.RespuestaOkay(producto) :
            RespuestaErrores.RespuestaSinRegistros<Paginacion<ProductoRtn>>("No hay registros de productos");
        }

        public async Task<Respuesta<ProductoRtn>> ObtenerProductoIdLogica(int id)
        {
            var productoId = await _productoRepo.ObtenerProductoIdAsync(id);
            return productoId != null ?
            RespuestaErrores.RespuestaOkay(productoId):
            RespuestaErrores.RespuestaSinRegistros<ProductoRtn>("No exsiste un producto con id : " + id);

        }
    }
}
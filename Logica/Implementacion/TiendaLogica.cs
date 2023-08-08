using Dominio.Entidades;
using Logica.Herramientas;
using Logica.Interfaz;
using Repositorio.Herramientas;
using Repositorio.Interfaz;

namespace Logica.Implementacion
{
    public class TiendaLogica : ITiendaLogica
    {
        private readonly ITiendaRepositorio _tiendaRepo;
        public TiendaLogica(ITiendaRepositorio tiendaRepo)
        {
            _tiendaRepo = tiendaRepo;
        }

        public async Task<Respuesta<Paginacion<ProductoRtn>>> ObtenerProductoLogica(Parametros parametros)
        {
            Paginacion<ProductoRtn> producto = await _tiendaRepo.ObtenerProductoAsync(parametros);
            return producto.Contador > 0 ?
            RespuestaErrores.RespuestaOkay(producto) :
            RespuestaErrores.RespuestaSinRegistros<Paginacion<ProductoRtn>>("No hay registros de productos");
        }

        public async Task<Respuesta<ProductoRtn>> ObtenerProductoIdLogica(int id)
        {
            var productoId = await _tiendaRepo.ObtenerProductoIdAsync(id);
            return productoId != null ?
            RespuestaErrores.RespuestaOkay<ProductoRtn>(productoId):
            RespuestaErrores.RespuestaSinRegistros<ProductoRtn>("No exsiste un producto con id : " + id);
        }

    }
}
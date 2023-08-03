using Dominio.Entidades;
using Logica.Herramientas;
using Logica.Interfaz;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;

namespace Logica.Implementacion
{
    public class ListaDesplegableLogica : IListaDesplegableLogica
    {
        private readonly IListaDesplegableRepositorio _listaRepo;
        private readonly IUnidadTrabajo _unidadTrabajo;
        public ListaDesplegableLogica(IListaDesplegableRepositorio listaRepo,
        IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
            _listaRepo = listaRepo;
        }

        public async Task<Respuesta<IReadOnlyList<Categoria>>> ObtenerCategoria()
        {
            IReadOnlyList<Categoria> categoria = await _listaRepo.ObtenerCategoriaAsync();
            return categoria != null ?  
            RespuestaErrores.RespuestaOkay(categoria):
            RespuestaErrores.RespuestaSinRegistros<IReadOnlyList<Categoria>>("No hay registros de categoria");
        }

        public async Task<Respuesta<IReadOnlyList<Estado>>> ObtenerEstado()
        {
             IReadOnlyList<Estado> estado = await _listaRepo.ObtenerEstadoAsync();
             return estado != null ?
             RespuestaErrores.RespuestaOkay(estado):
             RespuestaErrores.RespuestaSinRegistros<IReadOnlyList<Estado>>("No hay registros de estado");
        }
    }
}
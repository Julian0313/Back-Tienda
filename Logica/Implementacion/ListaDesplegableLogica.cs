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
        public ListaDesplegableLogica(IListaDesplegableRepositorio listaRepo)
        {
            _listaRepo = listaRepo;
        }

        public async Task<Respuesta<IReadOnlyList<Cargo>>> ObtenerCargoLogica()
        {
            IReadOnlyList<Cargo> cargo = await _listaRepo.ObtenerCargoAsync();
            return cargo != null ?
            RespuestaErrores.RespuestaOkay(cargo):
            RespuestaErrores.RespuestaSinRegistros<IReadOnlyList<Cargo>>("No hay registros de cargo");
        }

        public async Task<Respuesta<IReadOnlyList<Categoria>>> ObtenerCategoriaLogica()
        {
            IReadOnlyList<Categoria> categoria = await _listaRepo.ObtenerCategoriaAsync();
            return categoria != null ?  
            RespuestaErrores.RespuestaOkay(categoria):
            RespuestaErrores.RespuestaSinRegistros<IReadOnlyList<Categoria>>("No hay registros de categoria");
        }

        public async Task<Respuesta<IReadOnlyList<Estado>>> ObtenerEstadoLogica()
        {
             IReadOnlyList<Estado> estado = await _listaRepo.ObtenerEstadoAsync();
             return estado != null ?
             RespuestaErrores.RespuestaOkay(estado):
             RespuestaErrores.RespuestaSinRegistros<IReadOnlyList<Estado>>("No hay registros de estado");
        }
    }
}
using Dominio.Entidades;
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

        public async Task<IReadOnlyList<Categoria>> ObtenerCategoria()
        {
            try 
            {
                return await _listaRepo.ObtenerCategoriaAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener categoria.", ex);
            }
        }

        public async Task<IReadOnlyList<Estado>> ObtenerEstado()
        {
            try 
            {
                return await _listaRepo.ObtenerEstadoAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener estado.", ex);
            }
        }
    }
}
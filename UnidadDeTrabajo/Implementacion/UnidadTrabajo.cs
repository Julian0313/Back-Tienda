using AutoMapper;
using Dominio.Entidades;
using Repositorio.Implementacion;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;

namespace UnidadTrabajo.Implementacion
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly TiendaContexto _contexto;
        private IProductoRepositorio _productoRepositorio;
        private IListaDesplegableRepositorio _listaDesplegableRepositorio;
        private ITiendaRepositorio _tiendaRepositorio;
        private readonly IMapper _mapper;

        public UnidadTrabajo(TiendaContexto contexto, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = contexto;

        }

        public IProductoRepositorio ProductoRepositorio
        {
            get
            {
                if (_productoRepositorio == null)
                {
                    _productoRepositorio = new ProductoRepositorio(_contexto, _mapper);
                }
                return _productoRepositorio;
            }
        }

        public IListaDesplegableRepositorio ListaDesplegableRepositorio
        {
            get
            {
                if (_listaDesplegableRepositorio == null)
                {
                    _listaDesplegableRepositorio = new ListaDesplegableRepositorio(_contexto);
                }
                return _listaDesplegableRepositorio;
            }
        }

        public ITiendaRepositorio TiendaRepositorio 
        {
            get
            {
                if (_tiendaRepositorio  == null)
                {
                    _tiendaRepositorio  = new TiendaRepositorio(_contexto, _mapper);
                }
                return _tiendaRepositorio ;
            }
        }

        public async Task GuardarCambiosAsync()
        {
            try
            {
                await _contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar los cambios.", ex);
            }
        }
        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
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
        private IProductoRepositorio _productoRepo;
        private IListaDesplegableRepositorio _listaDesplegableRepo;
        private ITiendaRepositorio _tiendaRepo;
        private IEmpleadoRepositorio _empleadoRepo;
        private IClienteRepositorio _clienteRepo;
        private IUsuarioRepositorio _usuarioRepo;
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
                if (_productoRepo == null)
                {
                    _productoRepo = new ProductoRepositorio(_contexto, _mapper);
                }
                return _productoRepo;
            }
        }
        public IEmpleadoRepositorio EmpleadoRepositorio
        {
            get
            {
                if (_empleadoRepo == null)
                {
                    _empleadoRepo = new EmpleadoRepositorio(_contexto, _mapper);
                }
                return _empleadoRepo;
            }
        }

        public IListaDesplegableRepositorio ListaDesplegableRepositorio
        {
            get
            {
                if (_listaDesplegableRepo == null)
                {
                    _listaDesplegableRepo = new ListaDesplegableRepositorio(_contexto);
                }
                return _listaDesplegableRepo;
            }
        }

        public ITiendaRepositorio TiendaRepositorio 
        {
            get
            {
                if (_tiendaRepo  == null)
                {
                    _tiendaRepo  = new TiendaRepositorio(_contexto, _mapper);
                }
                return _tiendaRepo ;
            }
        }

        public IClienteRepositorio ClienteRepositorio
        {
            get
            {
                if(_clienteRepo == null)
                {
                    _clienteRepo = new ClienteRepositorio(_contexto, _mapper);
                }
                return _clienteRepo;
            }
        }
        public IUsuarioRepositorio usuarioRepositorio
        {
            get
            {
                if(_usuarioRepo == null)
                {
                    _usuarioRepo = new UsuarioRepositorio(_contexto);
                }
                return _usuarioRepo;
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
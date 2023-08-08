using AutoMapper;
using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Herramientas;
using Repositorio.Interfaz;

namespace Repositorio.Implementacion
{
    public class EmpleadoRepositorio : IEmpleadoRepositorio
    {
        private readonly TiendaContexto _contexto;
        private readonly IMapper _mapper;
        public EmpleadoRepositorio(TiendaContexto contexto, IMapper mapper)
        {
            _mapper = mapper;
            _contexto = contexto;
        }

        public async Task CrearEmpleadoAsync(Empleado empleado)
        {
            empleado.fechaCreacion = DateTime.Now;
            empleado.fechaModificacion = null;
            empleado.fkIdEstado = 1;
            _contexto.Empleado.Add(empleado);
            await _contexto.SaveChangesAsync();
        }

        public async  Task EditarEmpleadoAsync(Empleado empleado)
        {
            var editarEmpleado = await _contexto.Empleado.FindAsync(empleado.idEmpleado);

            editarEmpleado.documento = empleado.documento;
            editarEmpleado.primerNombre = empleado.primerNombre;
            editarEmpleado.segundoNombre = empleado.segundoNombre;
            editarEmpleado.primerApellido = empleado.primerApellido;
            editarEmpleado.segundoApellido = empleado.segundoApellido;
            editarEmpleado.telefono = empleado.telefono;
            editarEmpleado.direccion = empleado.direccion;
            editarEmpleado.correo = empleado.correo;
            editarEmpleado.fechaModificacion = DateTime.Now;
            editarEmpleado.fkIdEstado = empleado.fkIdEstado;
            editarEmpleado.fkIdCargo = empleado.fkIdCargo;

            await _contexto.SaveChangesAsync();
        }

        public async Task EliminarEmpleadoAsync(int id)
        {
            var eliminarEmpleado = await _contexto.Empleado.FindAsync(id);

            eliminarEmpleado.fkIdEstado = 0;
            eliminarEmpleado.fechaModificacion = DateTime.Now;

            await _contexto.SaveChangesAsync();
        }

        public async Task<Paginacion<EmpleadoRtn>> ObtenerEmpleadoAsync(Parametros parametros)
        {
            var empleados = _contexto.Empleado.AsQueryable();

            if (!string.IsNullOrEmpty(parametros.Buscar))
            {
                empleados = empleados.Where(p => p.documento.ToLower().Contains(parametros.Buscar) | p.primerNombre.ToLower().Contains(parametros.Buscar));
            }

            var contador = await empleados.CountAsync();

            var empleadosPag = await empleados
                .Include(e => e.Estado)
                .Include(c => c.Cargo)
                .Skip((parametros.PageIndex - 1) * parametros.PageSize)
                .Take(parametros.PageSize)
                .ToListAsync();

            var paginacion = new Paginacion<EmpleadoRtn>(
                parametros.PageIndex,
                parametros.PageSize,
                contador,
                _mapper.Map<IReadOnlyList<EmpleadoRtn>>(empleadosPag)
            );

            return paginacion;
        }

        public async Task<EmpleadoRtn> ObtenerEmpleadoDocumentoAsync(string documento)
        {
             var empleado = await _contexto.Empleado
                .Include(e => e.Estado)
                .Include(c => c.Cargo)
                .FirstOrDefaultAsync(x => x.documento == documento);

            return _mapper.Map<EmpleadoRtn>(empleado);
        }


        public async Task<EmpleadoRtn> ObtenerEmpleadoIdAsync(int id)
        {
             var empleado = await _contexto.Empleado
                .Include(e => e.Estado)
                .Include(c => c.Cargo)
                .FirstOrDefaultAsync(x => x.idEmpleado == id);

            return _mapper.Map<EmpleadoRtn>(empleado);
        }
    }
}
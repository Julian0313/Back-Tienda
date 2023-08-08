using Dominio.Entidades;
using Logica.Implementacion;
using Logica.Interfaz;
using LogicaNegocio.Implementacion;
using LogicaNegocio.Interfaz;
using Microsoft.EntityFrameworkCore;
using Repositorio.Herramientas;
using Repositorio.Implementacion;
using Repositorio.Interfaz;
using UnidadTrabajo.Interfaz;

namespace API.Extensiones
{
    public static class ExtensionServiciosAplicacion
    {
        public static IServiceCollection AgregarServiciosAplicacion(this IServiceCollection services,
        IConfiguration config)
        {
            services.AddDbContext<TiendaContexto>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("ConnectionSql"));
            });
            services.AddScoped<IProductoRepositorio, ProductoRepositorio>();
            services.AddScoped<IProductoLogica, ProductoLogica>();

            services.AddScoped<IListaDesplegableRepositorio, ListaDesplegableRepositorio>();
            services.AddScoped<IListaDesplegableLogica, ListaDesplegableLogica>();

            services.AddScoped<ITiendaRepositorio, TiendaRepositorio>();
            services.AddScoped<ITiendaLogica, TiendaLogica>();

            services.AddScoped<IEmpleadoRepositorio, EmpleadoRepositorio>();
            services.AddScoped<IEmpleadoLogica, EmpleadoLogica>();

            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IClienteLogica, ClienteLogica>();

            services.AddScoped<IUnidadTrabajo, UnidadTrabajo.Implementacion.UnidadTrabajo>();

            services.AddAutoMapper(typeof(PerfildeMapeo));
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
                });
            });

            return services;
        }
    }
}
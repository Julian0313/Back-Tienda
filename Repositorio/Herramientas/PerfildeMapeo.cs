using AutoMapper;
using Dominio.Entidades;

namespace Repositorio.Herramientas
{
    public class PerfildeMapeo : Profile
    {
        public PerfildeMapeo()
        {
            CreateMap<Producto, ProductoRtn>()
                .ForMember(dest => dest.fkIdEstado, opt => opt.MapFrom(src => src.Estado.nombre))
                .ForMember(dest => dest.fkIdCategoria, opt => opt.MapFrom(src => src.Categoria.nombre));
        }
    }
}
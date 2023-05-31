using AutoMapper;
using PatronRepositorio.Data;
using PatronRepositorio.Dtos;

namespace PatronRepositorio.AutoMapperProfiles
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles() {
            CreateMap<Hamburguesa, ComidaDto>()
                .ForMember(
                    dest=> dest.Nombre, 
                    opt => opt
                    .MapFrom(src=> src.Comida.Nombre)
                ).ForMember(
                    dest => dest.Venta,
                    opt => opt
                    .MapFrom(src => src.Comida.Venta)
                ).ForMember(
                    dest => dest.Type,
                    opt => opt
                    .MapFrom(src => ComidaType.Hamburguesa)
                ).ForMember(
                    dest => dest.MoreInfo,
                    opt => opt
                    .MapFrom(src => new
                    {
                        src.NumeroCarnes,
                        src.LlevaPepino
                    })
                )
                .ReverseMap();


            CreateMap<Alita, ComidaDto>()
                .ForMember(
                    dest => dest.Nombre,
                    opt => opt
                    .MapFrom(src => src.Comida.Nombre)
                ).ForMember(
                    dest => dest.Venta,
                    opt => opt
                    .MapFrom(src => src.Comida.Venta)
                ).ForMember(
                    dest => dest.Type,
                    opt => opt
                    .MapFrom(src => ComidaType.Alita)
                ).ForMember(
                    dest => dest.MoreInfo,
                    opt => opt
                    .MapFrom(src => new
                    {
                        src.NombreDelPollo,
                        src.EsMuslito
                    })
                )
                .ReverseMap();
        }
    }
}

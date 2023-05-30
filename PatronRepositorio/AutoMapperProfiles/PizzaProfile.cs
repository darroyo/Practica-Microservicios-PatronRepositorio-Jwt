using AutoMapper;
using PatronRepositorio.Data;
using PatronRepositorio.Dtos;

namespace PatronRepositorio.AutoMapperProfiles
{
    public class PizzaProfile:Profile
    {
        public PizzaProfile() {
            CreateMap<Pizza, PizzaDto>()
                .ForMember(
                    dest=> dest.Username, 
                    opt => opt
                    .MapFrom(src=> "MappedFrom: " + src.Username)
                )
                .ReverseMap();
        }
    }
}

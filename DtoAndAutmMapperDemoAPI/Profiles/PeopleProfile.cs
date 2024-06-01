using AutoMapper;
using DtoAndAutmMapperDemoAPI.Dtos;
using DtoAndAutmMapperDemoAPI.Models;

namespace DtoAndAutmMapperDemoAPI.Profiles
{
    public class PeopleProfile : Profile
    {
        public PeopleProfile()
        {
            // Source  -> Destination
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Age, 
                            opt => opt.MapFrom(src => src.YearsAlive));
        }
    }
}
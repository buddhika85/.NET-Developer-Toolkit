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
            // http get
            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Age, 
                            opt => opt.MapFrom(src => src.YearsAlive));
            
            // http post
            // create Dto --> DB Entity - to save in DB
            CreateMap<PersonCreateDto, Person>()
                .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            // Http put
            CreateMap<PersonUpdateDto, Person>()
             .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
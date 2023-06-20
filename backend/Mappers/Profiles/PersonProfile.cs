using AutoMapper;
using ProjectsManagement.Dtos.Person;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<CreatePersonDto, Person>();
        CreateMap<Person, ResponsePersonDto>();

    }

    // class members here
}

using AutoMapper;
using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class CountryProfile : Profile
{
    public CountryProfile()
    {
        CreateMap<CreateCountryDto, Country>();
        CreateMap<Country, ResponseCountryDto>();
    }

    // class members here
}

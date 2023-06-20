using AutoMapper;
using ProjectsManagement.Dtos.City;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class CityProfile : Profile
{
    public CityProfile()
    {
        CreateMap<CreateCityDto, City>();
        CreateMap<City, ResponseCityDto>();

    }

}

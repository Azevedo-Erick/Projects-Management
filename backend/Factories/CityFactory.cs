using ProjectsManagement.Dtos.City;
using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Dtos.State;
using ProjectsManagement.Models;

namespace ProjectsManagement.Factories;

public static class CityFactory
{
    public static ResponseCityDto FromModelToDto(City model)
    {
        return new ResponseCityDto(model.Name, StateFactory.FromModelToDto(model.State));
    }
    public static City FromDtoToModel(CreateCityDto dto)
    {
        return new City(dto.Name, dto.StateId);
    }


}

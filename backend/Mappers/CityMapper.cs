using ProjectsManagement.Dtos.City;
using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Dtos.State;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public static class CityMapper
{
    public static ResponseCityDto FromModelToDto(City model)
    {
        return new ResponseCityDto
        {
            Id = model.Id,
            Name = model.Name,
            State = StateMapper.FromModelToDto(model.State)
        };
    }
    public static City FromDtoToModel(CreateCityDto dto)
    {
        return new City(dto.Name, dto.StateId);
    }


}

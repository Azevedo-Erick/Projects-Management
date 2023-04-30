using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Dtos.State;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public static class StateMapper
{
    public static ResponseStateDto FromModelToDto(State model)
    {
        return new ResponseStateDto
        {
            Id = model.Id,
            Name = model.Name,
            Country = CountryMapper.FromModelToDto(model.Country)
        };
    }
    public static State FromDtoToModel(CreateStateDto dto)
    {
        return new State
        {
            Name = dto.Name,
            CountryId = dto.CountryId
        };
    }


}

using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Dtos.State;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public static class StateMapper
{
    public static ResponseStateDto FromModelToDto(State model)
    {
        return new ResponseStateDto(model.Name, CountryMapper.FromModelToDto(model.Country));
    }
    public static State FromDtoToModel(CreateStateDto dto)
    {
        return new State(dto.Name, dto.CountryId);
    }


}

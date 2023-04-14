using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Dtos.State;
using ProjectsManagement.Models;

namespace ProjectsManagement.Factories;

public static class StateFactory
{
    public static ResponseStateDto FromModelToDto(State model)
    {
        return new ResponseStateDto(model.Name, CountryFactory.FromModelToDto(model.Country));
    }
    public static State FromDtoToModel(CreateStateDto dto)
    {
        return new State(dto.Name, dto.CountryId);
    }


}

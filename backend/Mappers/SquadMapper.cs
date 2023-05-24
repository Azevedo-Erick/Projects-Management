using ProjectsManagement.Dtos.Role;
using ProjectsManagement.Dtos.Squad;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public static class SquadMapper
{
    public static ResponseSquadDto FromModelToDto(Squad model)
    {
        return new ResponseSquadDto();
    }
    public static Squad FromDtoToModel(CreateSquadDto dto)
    {
        return new Squad();
    }
}

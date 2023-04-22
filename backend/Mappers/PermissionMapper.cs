using ProjectsManagement.Dtos.Permission;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public class PermissionMapper
{
    public static ResponsePermissionDto FromModelToDto(Permission model)
    {
        return new ResponsePermissionDto();
    }
    public static Permission FromDtoToModel(CreatePermissionDto dto)
    {
        return new Permission();
    }
}

using ProjectsManagement.Dtos.Role;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public class RoleMapper
{
    public static ResponseRoleDto FromModelToDto(Role model)
    {
        return new ResponseRoleDto();
    }
    public static Role FromDtoToModel(CreateRoleDto dto)
    {
        return new Role();
    }
}

using ProjectsManagement.Dtos.Permission;

namespace ProjectsManagement.Dtos.Role;
public class ResponseRoleDto
{
    public string Name { get; set; }
    public List<ResponsePermissionDto> Permissions { get; set; }
    public ResponseRoleDto()
    {
    }

}

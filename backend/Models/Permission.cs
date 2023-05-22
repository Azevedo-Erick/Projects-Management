namespace ProjectsManagement.Models;

public class Permission : BaseEntity
{

    public string Name { get; set; }
    public List<RolePermission>? Roles { get; set; }

}
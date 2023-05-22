namespace ProjectsManagement.Models;


public class Role : BaseEntity
{
    public string Name { get; set; }
    public List<RolePermission>? Permissions { get; set; }
}
namespace ProjectsManagement.Models;


public class Role : BaseEntity
{

    public List<Permission> Permissions { get; set; }
}
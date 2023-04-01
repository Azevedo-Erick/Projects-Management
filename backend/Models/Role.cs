namespace ProjectsManagement.Models;


public class Role
{
    public int Id { get; set; }
    public List<Permission> Permissions { get; set; }
}
namespace ProjectsManagement.Dtos.Role;

public class CreateRoleDto
{

    public string Name { get; set; }
    public List<int> Permissions { get; set; }
    public CreateRoleDto()
    {
        // constructor logic here
    }

    // class members here
}

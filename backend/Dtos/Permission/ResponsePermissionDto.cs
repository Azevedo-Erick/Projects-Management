namespace ProjectsManagement.Dtos.Permission;

public record ResponsePermissionDto
{

    public string Name { get; set; }
    public bool Has { get; set; }
    public ResponsePermissionDto()
    {
    }

}

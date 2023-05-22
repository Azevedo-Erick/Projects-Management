namespace ProjectsManagement.Dtos.Project;

public struct CreateProjectDto
{
    public string Name { get; set; }
    public int Manager { get; set; }
    public string Release { get; set; }


    public int ManagerId { get; set; }

}

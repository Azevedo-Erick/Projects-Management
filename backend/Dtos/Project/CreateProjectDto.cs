using System.ComponentModel.DataAnnotations;

namespace ProjectsManagement.Dtos.Project;

public struct CreateProjectDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Release { get; set; }

    [Required]
    public int ManagerId { get; set; }
}

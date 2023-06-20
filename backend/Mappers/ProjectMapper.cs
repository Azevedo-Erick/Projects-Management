using ProjectsManagement.Dtos.Project;
using ProjectsManagement.Dtos.Role;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public class ProjectMapper
{
    public static ResponseProjectDto FromModelToDto(Project model)
    {
        return new ResponseProjectDto
        {
            Name = model.Name,
            Id = model.Id,
            /* Milestones = model.Milestones, */
            Release = model.Release
        };
    }
    public static Project FromDtoToModel(CreateProjectDto dto)
    {
        return new Project();
    }
}

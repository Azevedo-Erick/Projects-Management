using AutoMapper;
using ProjectsManagement.Dtos.Project;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<CreateProjectDto, Project>();
        CreateMap<Project, ResponseProjectDto>();
    }

    // class members here
}

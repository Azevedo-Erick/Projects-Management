using AutoMapper;
using ProjectsManagement.Dtos.Task;

namespace ProjectsManagement.Mappers.Profiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<CreateTaskDto, ProjectsManagement.Models.Task>();
        CreateMap<ProjectsManagement.Models.Task, ResponseTaskDto>();

    }

}

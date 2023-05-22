
using ProjectsManagement.Dtos.Role;
using ProjectsManagement.Dtos.Task;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public class TaskMapper
{
    public static ResponseTaskDto FromModelToDto(Models.Task model)
    {
        return new ResponseTaskDto();
    }
    public static Models.Task FromDtoToModel(CreateTaskDto dto)
    {
        return new Models.Task();
    }
}

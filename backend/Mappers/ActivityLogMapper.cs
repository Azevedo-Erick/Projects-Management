using ProjectsManagement.Dtos.ActivityLog;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public class ActivityLogMapper
{
    public static ResponseActivityLogDto FromModelToDto(ActivityLog model)
    {
        return new ResponseActivityLogDto();
    }
    public static ActivityLog FromDtoToModel(CreateActivityLogDto dto)
    {
        return new ActivityLog();
    }
}
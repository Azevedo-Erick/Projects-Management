using ProjectsManagement.Dtos.ActivityType;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public class ActivityTypeMapper
{
    public static ResponseActivityTypeDto FromModelToDto(ActivityType model)
    {
        return new ResponseActivityTypeDto();
    }
    public static ActivityType FromDtoToModel(CreateActivityTypeDto dto)
    {
        return new ActivityType();
    }
}
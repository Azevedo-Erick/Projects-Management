using AutoMapper;
using ProjectsManagement.Dtos.ActivityType;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class ActivityTypeProfile : Profile
{
    public ActivityTypeProfile()
    {
        CreateMap<CreateActivityTypeDto, ActivityType>();
        CreateMap<ActivityType, ResponseActivityTypeDto>();

    }

    // class members here
}

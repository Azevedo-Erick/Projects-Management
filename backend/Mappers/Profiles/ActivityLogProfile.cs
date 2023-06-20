using AutoMapper;
using ProjectsManagement.Dtos.ActivityLog;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class ActivityLogProfile : Profile
{
    public ActivityLogProfile()
    {
        CreateMap<CreateActivityLogDto, ActivityLog>();
        CreateMap<ActivityLog, ResponseActivityLogDto>();

    }

    // class members here
}

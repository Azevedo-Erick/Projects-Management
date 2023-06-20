using AutoMapper;
using ProjectsManagement.Dtos.NotificationType;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class NotificationTypeProfile : Profile
{
    public NotificationTypeProfile()
    {
        CreateMap<CreateNotificationTypeDto, NotificationType>();
        CreateMap<NotificationType, ResponseNotificationTypeDto>();

    }

    // class members here
}

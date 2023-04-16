using ProjectsManagement.Dtos.Notification;
using ProjectsManagement.Models;

namespace  ProjectsManagement.Mappers;
public class NotificationMapper{
    public static ResponseNotificationDto FromModelToDto(Notification model)
    {
        return new ResponseNotificationDto();
    }
    public static Notification FromDtoToModel(CreateNotificationDto dto)
    {
        return new Notification();
    }
}
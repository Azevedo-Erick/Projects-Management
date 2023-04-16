using ProjectsManagement.Dtos.NotificationType;
using ProjectsManagement.Models;

namespace  ProjectsManagement.Mappers;
public class NotificationTypeMapper{

    public static ResponseNotificationTypeDto FromModelToDto(NotificationType model)
    {
        return new ResponseNotificationTypeDto();
    }
    public static NotificationType FromDtoToModel(CreateNotificationTypeDto dto)
    {
        return new NotificationType();
    }
}
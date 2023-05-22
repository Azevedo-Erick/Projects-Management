using ProjectsManagement.Dtos.Notification;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;
public class NotificationMapper
{
    public static ResponseNotificationDto FromModelToDto(Notification model)
    {
        return new ResponseNotificationDto
        {
            IsRead = model.IsRead,
            Message = model.Message,
            Recipient = PersonMapper.FromModelToDto(model.Recipient),
            Type = model.Type.Name
        };
    }
    public static Notification FromDtoToModel(CreateNotificationDto dto)
    {
        return new Notification
        {
            Message = dto.Message,
            RecipientId = dto.RecipientId,
            TypeId = dto.TypeId,
        };
    }
}
namespace ProjectsManagement.Dtos.Notification;

public class CreateNotificationDto
{
    public string Message { get; set; }
    public int RecipientId { get; set; }
    public int TypeId { get; set; }
}
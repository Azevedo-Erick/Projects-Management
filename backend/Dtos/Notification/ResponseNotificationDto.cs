using ProjectsManagement.Models;

namespace ProjectsManagement.Dtos.Notification;

public class ResponseNotificationDto
{
    public string Message { get; set; }
    public string Type { get; set; }
    public bool IsRead { get; set; }
    public Person Recipient { get; set; }


}
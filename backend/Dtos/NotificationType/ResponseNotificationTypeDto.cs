namespace ProjectsManagement.Dtos.NotificationType;

public class ResponseNotificationTypeDto
{
    public string Name { get; set; }

    public ResponseNotificationTypeDto(string name)
    {
        Name = name;
    }

    public ResponseNotificationTypeDto()
    {
    }
}
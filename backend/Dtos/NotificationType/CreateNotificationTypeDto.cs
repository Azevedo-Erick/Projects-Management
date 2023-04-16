namespace ProjectsManagement.Dtos.NotificationType;

public class CreateNotificationTypeDto
{
    public string Name { get; set; }

    public CreateNotificationTypeDto()
    {
    }

    public CreateNotificationTypeDto(string name)
    {
        Name = name;
    }
}
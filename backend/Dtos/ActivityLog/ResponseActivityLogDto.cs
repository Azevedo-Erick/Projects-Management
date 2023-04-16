namespace ProjectsManagement.Dtos.ActivityLog;

public class ResponseActivityLogDto
{
    public DateTime Timestamp { get; set; }
    public string Description { get; set; }
    public int Person { get; set; }
    public int ResponseActivityTypeDto { get; set; }
}
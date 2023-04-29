namespace ProjectsManagement.Dtos.ActivityLog;

public record CreateActivityLogDto
{
    public DateTime Timestamp { get; set; }
    public string Description { get; set; }
    public int PersonId { get; set; }
    public int ActivityTypeId { get; set; }
}
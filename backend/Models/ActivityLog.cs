namespace ProjectsManagement.Models;

public class ActivityLog
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public Person Person { get; set; }
    public ActivityType ActivityType { get; set; }
    public string Description { get; set; }


    public int PersonId { get; set; }
    public int ActivityTypeId { get; set; }
}
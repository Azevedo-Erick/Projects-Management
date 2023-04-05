namespace ProjectsManagement.Models;


public class ActivityType : BaseEntity
{

    public string Name { get; set; }
    public List<ActivityLog> Logs { get; set; }
}
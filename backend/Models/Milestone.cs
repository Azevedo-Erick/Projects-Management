namespace ProjectsManagement.Models;

public class Milestone : BaseEntity
{

    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DeadLine { get; set; }
    public List<Task> Tasks { get; set; }
}
namespace ProjectsManagement.Models;

public class Milestone
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateOnly StartDate { get; set; }
    public DateTime DeadLine { get; set; }
    public List<Task> Tasks { get; set; }
}
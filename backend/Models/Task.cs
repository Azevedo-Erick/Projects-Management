namespace ProjectsManagement.Models;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    public Person Assigner { get; set; }
    public List<Employee> AssignedTo { get; set; }
    public List<Tag> Tags { get; set; }
    public List<Issue> Issues { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ConclusionDate { get; set; }
    public DateTime DeadLine { get; set; }

    public int AssignerId { get; set; }


}
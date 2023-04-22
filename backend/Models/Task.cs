namespace ProjectsManagement.Models;

public class Task : BaseEntity
{

    public string Title { get; set; }
    public string Description { get; set; }

    public Person Assigner { get; set; }
    public List<TaskAssignment> Assignments { get; set; }
    public List<Tag> Tags { get; set; }
    public List<Issue> Issues { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ConclusionDate { get; set; }
    public DateTime DeadLine { get; set; }

    public int AssignerId { get; set; }


}
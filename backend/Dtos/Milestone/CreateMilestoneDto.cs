namespace ProjectsManagement.Dtos.Milestone;

public class CreateMilestoneDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime DeadLine { get; set; }
    public List<int> Tasks { get; set; }
    public int Project { get; set; }
}

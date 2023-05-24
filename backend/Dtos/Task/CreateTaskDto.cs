namespace ProjectsManagement.Dtos.Task;

public class CreateTaskDto
{
    public string Title { get; set; }
    public string Description { get; set; }

    public int Assigner { get; set; }
    public List<int> Assignments { get; set; }
    public List<int> Tags { get; set; }

    public List<int> Issues { get; set; }
    public int Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime ConclusionDate { get; set; }
    public DateTime DeadLine { get; set; }
}
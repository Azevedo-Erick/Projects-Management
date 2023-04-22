namespace ProjectsManagement.Models;

public class TaskAssignment
{
    public int PersonId { get; set; }
    public Person Person { get; set; }

    public int TaskId { get; set; }
    public Task Task { get; set; }
}

namespace ProjectsManagement.Models;

public class TaskAssignment
{
    public int MemberId { get; set; }
    public Member Member { get; set; }

    public int TaskId { get; set; }
    public Task Task { get; set; }
}

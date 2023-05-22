namespace ProjectsManagement.Models;

public class TaskStatus : BaseEntity
{
    public string Name { get; set; }
    public List<Task>? Tasks { get; set; }
    public TaskStatus()
    {
        // constructor logic here
    }

    // class members here
}

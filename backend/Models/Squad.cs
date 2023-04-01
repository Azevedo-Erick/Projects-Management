namespace ProjectsManagement.Models;

public class Squad
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Employee Leader { get; set; }
    public List<Person> Team { get; set; }
    public List<Task> Tasks { get; set; }


    public int LeaderId { get; set; }
}
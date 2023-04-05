namespace ProjectsManagement.Models;

public class Squad : BaseEntity
{

    public string Name { get; set; }
    public Employee Leader { get; set; }
    public List<Person> Team { get; set; }


    public int LeaderId { get; set; }
}
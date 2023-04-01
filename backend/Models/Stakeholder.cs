namespace ProjectsManagement.Models;

public class Stakeholder
{
    public int Id { get; set; }
    public Person Person { get; set; }
    public List<Project> Projects { get; set; }


    public int PersonId { get; set; }
}
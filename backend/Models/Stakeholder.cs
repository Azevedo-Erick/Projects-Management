namespace ProjectsManagement.Models;

public class Stakeholder : BaseEntity
{

    public Person Person { get; set; }
    public List<Project> Projects { get; set; }


    public int PersonId { get; set; }
}
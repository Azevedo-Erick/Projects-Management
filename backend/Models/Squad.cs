namespace ProjectsManagement.Models;

public class Squad : BaseEntity
{

    public string Name { get; set; }
    public Person Leader { get; set; }
    public List<Member> Team { get; set; }


    public int LeaderId { get; set; }
}
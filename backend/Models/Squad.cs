namespace ProjectsManagement.Models;

public class Squad : BaseEntity
{

    public string Name { get; set; }
    public List<Member> Team { get; set; }


}
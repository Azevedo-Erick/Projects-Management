namespace ProjectsManagement.Models;

public class Project : BaseEntity
{

    public string Name { get; set; }
    public Member Manager { get; set; }
    public string Release { get; set; }
    public List<Squad> Squads { get; set; }
    public List<Issue> Issues { get; set; }

    public List<Member> Members { get; set; }
    public List<Milestone> Milestones { get; set; }


    public int ManagerId { get; set; }
}
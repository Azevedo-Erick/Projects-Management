namespace ProjectsManagement.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Person Manager { get; set; }
    public string Release { get; set; }
    public List<Squad> Squads { get; set; }
    public List<Task> Tasks { get; set; }
    public List<Milestone> Milestones { get; set; }


    public int ManagerId { get; set; }
}
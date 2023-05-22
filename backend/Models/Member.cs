namespace ProjectsManagement.Models;

public class Member : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Person Person { get; set; }
    public Role Role { get; set; }
    public List<TaskAssignment> Tasks { get; set; }

    public int RoleId { get; set; }
    public int PersonId { get; set; }

}
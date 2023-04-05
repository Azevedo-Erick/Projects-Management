namespace ProjectsManagement.Models;

public class City : BaseEntity
{

    public string Name { get; set; }
    public State State { get; set; }
    public int StateId { get; set; }
}
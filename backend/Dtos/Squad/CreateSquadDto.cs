namespace ProjectsManagement.Dtos.Squad;

public class CreateSquadDto
{
    public string Name { get; set; }
    public List<int> Members { get; set; }


    public int LeaderId { get; set; }
}

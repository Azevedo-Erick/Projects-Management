namespace ProjectsManagement.Models;

public class State : BaseEntity
{

    public string Name { get; set; }
    public Country Country { get; set; }


    public int CountryId { get; set; }
}
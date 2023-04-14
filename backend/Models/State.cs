namespace ProjectsManagement.Models;

public class State : BaseEntity
{

    public string Name { get; set; }
    public Country Country { get; set; }


    public int CountryId { get; set; }

    public State(string name, Country country, int countryId)
    {
        Name = name;
        Country = country;
        CountryId = countryId;
    }

    public State(string name, Country country)
    {
        Name = name;
        Country = country;
    }

    public State(string name, int countryId)
    {
        Name = name;
        CountryId = countryId;
        Country = new Country();
    }

    public State()
    {
        Name = "";
    }
}
namespace ProjectsManagement.Models;

public class Country : BaseEntity
{
    public Country(string name)
    {
        Name = name;
    }

    public Country()
    {
    }

    public string Name { get; set; }
}
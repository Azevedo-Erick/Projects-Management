namespace ProjectsManagement.Models;

public class ContactType : BaseEntity
{
    public ContactType()
    {
    }

    public ContactType(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
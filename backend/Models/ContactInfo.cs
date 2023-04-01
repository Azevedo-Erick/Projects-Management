namespace ProjectsManagement.Models;

public class ContactInfo
{
    public int Id { get; set; }
    public string Value { get; set; }
    public ContactType Type { get; set; }


    public int ContactTypeId { get; set; }

}
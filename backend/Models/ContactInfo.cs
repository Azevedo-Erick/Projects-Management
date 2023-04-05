namespace ProjectsManagement.Models;

public class ContactInfo : BaseEntity
{

    public string Value { get; set; }
    public ContactType Type { get; set; }


    public int ContactTypeId { get; set; }

}
namespace ProjectsManagement.Models;

public class ContactInfo : BaseEntity
{
    public ContactInfo()
    {
    }

    public ContactInfo(string value, ContactType type)
    {
        Value = value;
        Type = type;
    }

    public ContactInfo(string value, int contactTypeId)
    {
        Value = value;
        ContactTypeId = contactTypeId;
    }

    public ContactInfo(string value, ContactType type, int contactTypeId)
    {
        Value = value;
        Type = type;
        ContactTypeId = contactTypeId;
    }


    public ContactType Type { get; set; }

    public string Value { get; set; }
    public int ContactTypeId { get; set; }


}
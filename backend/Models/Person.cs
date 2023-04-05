namespace ProjectsManagement.Models;

public class Person : BaseEntity
{

    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public Role Role { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ProfileImage { get; set; }
    public List<ContactInfo> Contacts { get; set; }
    public Address Address { get; set; }


    public int AddressId { get; set; }
    public int RoleId { get; set; }
}
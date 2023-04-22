namespace ProjectsManagement.Models;

public class Person : BaseEntity
{

    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime DateOfBirth { get; set; }

    public List<TaskAssignment> Tasks { get; set; }
    public List<Issue> Issue { get; set; }


    public string ProfileImage { get; set; }
    public List<ContactInfo> Contacts { get; set; }
    public List<Address> Addresses { get; set; }


}
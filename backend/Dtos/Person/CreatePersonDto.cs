namespace ProjectsManagement.Dtos.Person;

public class CreatePersonDto
{

    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public DateTime DateOfBirth { get; set; }

    public string ProfileImage { get; set; }
    public List<int> Contacts { get; set; }
    public List<int> Addresses { get; set; }

    public CreatePersonDto()
    {
        // constructor logic here
    }

    // class members here

}
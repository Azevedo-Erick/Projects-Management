using ProjectsManagement.Dtos.ContactInfo;

namespace  ProjectsManagement.Dtos.Person;

public class ResponsePersonDto
{
     public string Name { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }

    public string ProfileImage { get; set; }
    public List<ResponseContactInfoDto> Contacts { get; set; }
    public List<int> Addresses { get; set; }
    public ResponsePersonDto()
    {
        // constructor logic here
    }

    // class members here

}
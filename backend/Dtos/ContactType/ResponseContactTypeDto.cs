namespace ProjectsManagement.Dtos.ContactType;

public class ResponseContactTypeDto
{
    public string Name { get; set; }
    public ResponseContactTypeDto()
    {
    }

    public ResponseContactTypeDto(string name)
    {
        Name = name;
    }
}

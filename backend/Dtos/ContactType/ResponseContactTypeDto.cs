namespace ProjectsManagement.Dtos.ContactType;

public record ResponseContactTypeDto
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

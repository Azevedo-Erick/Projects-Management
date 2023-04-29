namespace ProjectsManagement.Dtos.ContactInfo;

public record ResponseContactInfoDto
{
    public string Value { get; set; }
    public string Type { get; set; }
    public ResponseContactInfoDto()
    {
    }

    public ResponseContactInfoDto(string value, string type)
    {
        Value = value;
        Type = type;
    }
}

using ProjectsManagement.Dtos.Country;

namespace ProjectsManagement.Dtos.State;

public record ResponseStateDto
{
    public string Name { get; set; }
    public ResponseCountryDto Country { get; set; }

    public ResponseStateDto(string name, ResponseCountryDto country)
    {
        Name = name;
        Country = country;
    }
}

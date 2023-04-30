using ProjectsManagement.Dtos.Country;

namespace ProjectsManagement.Dtos.State;

public record ResponseStateDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ResponseCountryDto Country { get; set; }


}

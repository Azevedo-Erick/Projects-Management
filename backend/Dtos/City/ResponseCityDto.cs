using ProjectsManagement.Dtos.State;

namespace ProjectsManagement.Dtos.City;

public record ResponseCityDto
{

    public int Id { get; set; }
    public string Name { get; set; }
    public ResponseStateDto State { get; set; }

}

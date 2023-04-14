using ProjectsManagement.Dtos.State;

namespace ProjectsManagement.Dtos.City;

public class ResponseCityDto
{
    public ResponseCityDto(string name, ResponseStateDto state)
    {
        Name = name;
        State = state;
    }

    public string Name { get; set; }
    public ResponseStateDto State { get; set; }

}

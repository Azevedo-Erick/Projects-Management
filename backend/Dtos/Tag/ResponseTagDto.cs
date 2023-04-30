namespace ProjectsManagement.Dtos.Tag;

public record ResponseTagDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string HexColor { get; set; }
    public ResponseTagDto()
    {
        // constructor logic here
    }

    // class members here
}

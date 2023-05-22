namespace ProjectsManagement.Dtos.Login;

public record RequestLoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}

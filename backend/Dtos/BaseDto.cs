namespace ProjectsManagement.Dtos;

public abstract class BaseDto
{
    protected BaseDto(int statusCode)
    {
        StatusCode = statusCode;
    }

    protected BaseDto(int statusCode, List<string> errors)
    {
        StatusCode = statusCode;
        Errors = errors;
    }

    public int StatusCode { get; private set; }
    public List<string> Errors { get; private set; } = new();


}
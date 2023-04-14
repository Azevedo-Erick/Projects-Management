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
    }

    public int StatusCode { get; private set; }


}
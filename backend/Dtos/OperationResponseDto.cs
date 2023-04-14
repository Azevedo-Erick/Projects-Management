namespace ProjectsManagement.Dtos;

public class OperationResponseDto : BaseDto
{
    public List<string> Errors { get; private set; } = new();

    public OperationResponseDto(List<string> errors, int statusCode = 400) : base(statusCode)
    {
        Errors.AddRange(errors);
    }

    public OperationResponseDto(string error, int statusCode = 400) : base(statusCode)
    {
        Errors.Add(error);
    }
}

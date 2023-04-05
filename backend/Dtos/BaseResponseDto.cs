namespace ProjectsManagement.Dtos;


public class BaseResponseDto<T> : BaseDto
{
    public T Data { get; private set; }
    public PaginationDto Pagination { get; private set; }


    public BaseResponseDto(T data, List<string> errors, int statusCode = 200) : base(statusCode, errors)
    {
        Data = data;
    }

    public BaseResponseDto(List<string> errors, int statusCode = 400) : base(statusCode, errors)
    {
    }

    public BaseResponseDto(string error, int statusCode = 400) : base(statusCode)
    {
        Errors.Add(error);

    }

    public BaseResponseDto(T data, int statusCode = 200) : base(statusCode)
    {
        Data = data;
    }
}
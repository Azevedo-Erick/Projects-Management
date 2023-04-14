namespace ProjectsManagement.Dtos;


public class BaseResponseDto<T> : BaseDto
{
    public List<T> Data { get; private set; } = new List<T>();
    public PaginationDto Pagination { get; private set; } = new();



    public BaseResponseDto(List<T> data, int statusCode = 200) : base(statusCode)
    {
        Data = data;
    }
    public BaseResponseDto(T data, int statusCode = 200) : base(statusCode)
    {
        Data.Add(data);
    }
    public BaseResponseDto(int statusCode = 200) : base(statusCode)
    {
    }


}
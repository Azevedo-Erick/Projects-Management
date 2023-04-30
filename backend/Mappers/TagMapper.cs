using ProjectsManagement.Dtos.Tag;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public class TagMapper
{
    public static ResponseTagDto FromModelToDto(Tag model)
    {
        return new ResponseTagDto
        {
            Id = model.Id,
            HexColor = model.HexColor,
            Title = model.Title
        };
    }
    public static Tag FromDtoToModel(CreateTagDto dto)
    {
        return new Tag
        {
            HexColor = dto.HexColor,
            Title = dto.Title
        };
    }
}

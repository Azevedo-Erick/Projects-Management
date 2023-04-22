using ProjectsManagement.Dtos.Tag;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public class TagMapper
{
    public static ResponseTagDto FromModelToDto(Tag model)
    {
        return new ResponseTagDto();
    }
    public static Tag FromDtoToModel(CreateTagDto dto)
    {
        return new Tag();
    }
}

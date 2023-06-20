using AutoMapper;
using ProjectsManagement.Dtos.Tag;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<CreateTagDto, Tag>();
        CreateMap<Tag, ResponseTagDto>();

    }

    // class members here
}

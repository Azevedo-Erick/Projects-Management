using AutoMapper;
using ProjectsManagement.Dtos.Permission;

namespace ProjectsManagement.Mappers.Profiles;
public class PermissionProfile : Profile
{
    public PermissionProfile()
    {
        CreateMap<CreatePermissionDto, ProjectsManagement.Models.Permission>();
        CreateMap<ProjectsManagement.Models.Permission, ResponsePermissionDto>();

    }

    // class members here
}

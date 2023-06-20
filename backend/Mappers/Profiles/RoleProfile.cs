using AutoMapper;
using ProjectsManagement.Dtos.Role;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {
        CreateMap<CreateRoleDto, Role>();
        CreateMap<Role, ResponseRoleDto>();
    }

    // class members here
}

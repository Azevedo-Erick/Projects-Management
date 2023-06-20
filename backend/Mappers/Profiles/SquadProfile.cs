using AutoMapper;
using ProjectsManagement.Dtos.State;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class SquadProfile : Profile
{
    public SquadProfile()
    {
        CreateMap<CreateStateDto, State>();
        CreateMap<State, ResponseStateDto>();
    }

    // class members here
}

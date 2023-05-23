using ProjectsManagement.Dtos.Milestone;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public static class MilestoneMapper
{
    public static ResponseMilestoneDto FromModelToDto(Milestone model)
    {
        return new ResponseMilestoneDto();
    }
    public static Milestone FromDtoToModel(CreateMilestoneDto dto)
    {
        return new Milestone();
    }
}

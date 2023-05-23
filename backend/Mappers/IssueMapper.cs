using ProjectsManagement.Dtos.ContactType;
using ProjectsManagement.Dtos.Issue;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public static class IssueMapper
{
    public static ResponseIssueDto FromModelToDto(Issue model)
    {
        return new ResponseIssueDto();
    }
    public static Issue FromDtoToModel(CreateIssueDto dto)
    {
        return new Issue();
    }
}

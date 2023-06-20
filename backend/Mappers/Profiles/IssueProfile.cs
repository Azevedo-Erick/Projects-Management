using AutoMapper;
using ProjectsManagement.Dtos.Issue;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;
public class IssueProfile : Profile
{
    public IssueProfile()
    {
        CreateMap<CreateIssueDto, Issue>();
        CreateMap<Issue, ResponseIssueDto>();

    }

    // class members here
}

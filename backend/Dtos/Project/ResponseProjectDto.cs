using ProjectsManagement.Dtos.Issue;
using ProjectsManagement.Dtos.Member;
using ProjectsManagement.Dtos.Milestone;
using ProjectsManagement.Dtos.Squad;

namespace ProjectsManagement.Dtos.Project;

public struct ResponseProjectDto
{
    public string Name { get; set; }
    public ResponseMemberDto Manager { get; set; }
    public string Release { get; set; }
    public List<ResponseSquadDto> Squads { get; set; }
    public List<ResponseIssueDto> Issues { get; set; }
    public List<ResponseMilestoneDto> Milestones { get; set; }
}

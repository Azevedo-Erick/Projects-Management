namespace ProjectsManagement.Dtos.Issue;

public struct CreateIssueDto
{
    public string Title { get; set; }
    public string Text { get; set; }
    public int Author { get; set; }
    public int Project { get; set; }
}

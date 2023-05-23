namespace ProjectsManagement.Dtos.Ticket;

public class CreateTicketDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int AuthorId { get; set; }
    public int ProjectId { get; set; }
    public DateTime ResolutionDate { get; set; }
}

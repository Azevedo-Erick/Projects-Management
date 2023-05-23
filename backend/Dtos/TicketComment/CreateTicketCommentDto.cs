namespace ProjectsManagement.Dtos.TicketComment;

public class CreateTicketCommentDto
{
    public string Text { get; set; }

    public int TicketId { get; set; }
    public int AuthorId { get; set; }
}

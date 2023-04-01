namespace ProjectsManagement.Models;

public class TicketComment
{
    public int Id { get; set; }
    public string Text { get; set; }
    public Person Author { get; set; }
    public Ticket Ticket { get; set; }

    public int TicketId { get; set; }
}
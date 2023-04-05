namespace ProjectsManagement.Models;

public class TicketComment : BaseEntity
{

    public string Text { get; set; }
    public Person Author { get; set; }
    public Ticket Ticket { get; set; }

    public int TicketId { get; set; }
    public int AuhtorId { get; set; }
}
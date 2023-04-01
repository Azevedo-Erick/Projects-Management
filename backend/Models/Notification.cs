using Microsoft.Data.SqlClient;

namespace ProjectsManagement.Models;

public class Notification
{
    public int Id { get; set; }
    public string Message { get; set; }
    public NotificationType Type { get; set; }
    public bool IsRead { get; set; }
    public Person Recipient { get; set; }


    public int RecipientId { get; set; }
    public int TypeId { get; set; }
}
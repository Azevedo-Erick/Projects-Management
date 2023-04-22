namespace ProjectsManagement.Models;

public class Ticket : BaseEntity
{

    public string Title { get; set; }
    public string Description { get; set; }
    public Person Author { get; set; }
    public Project Project { get; set; }
    public DateTime ResolutionDate { get; set; }

    public int AuthorId { get; set; }
    //public int ProjectId { get; set; }

}
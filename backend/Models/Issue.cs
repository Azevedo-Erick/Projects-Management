namespace ProjectsManagement.Models;

public class Issue : BaseEntity
{

    public string Title { get; set; }
    public string Text { get; set; }
    public Person? Author { get; set; }
    public Project? Project { get; set; }


    public int? AuthorId { get; set; }
    public int? ProjectId { get; set; }

}
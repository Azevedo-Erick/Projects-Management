namespace ProjectsManagement.Models;

public class Issue : BaseEntity
{

    public string Title { get; set; }
    public string Text { get; set; }
    public Person Author { get; set; }
    public Task Task { get; set; }


    public int AuthorId { get; set; }
    public int TaskId { get; set; }

}
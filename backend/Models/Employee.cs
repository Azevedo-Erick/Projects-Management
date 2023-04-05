using System.Threading.Tasks;
namespace ProjectsManagement.Models;

public class Employee : BaseEntity
{

    public List<Task> Tasks { get; set; }
    public Person Person { get; set; }


    public int PersonId { get; set; }

}
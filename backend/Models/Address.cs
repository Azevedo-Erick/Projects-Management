namespace ProjectsManagement.Models;

public class Address : BaseEntity
{

    public string Street { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public City City { get; set; }
    public string ZipCode { get; set; }

    public int CityId { get; set; }
}
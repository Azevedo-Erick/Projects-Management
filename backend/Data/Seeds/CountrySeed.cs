using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Seeds;

public class CountrySeed
{

    public static List<Country> GetCountries()
    {
        List<Country> countries = new List<Country>
{
    new Country { Id = 1, Name = "United States" },
    new Country { Id = 2, Name = "Canada" },
    new Country { Id = 3, Name = "Mexico" },
    new Country { Id = 4, Name = "Brazil" },
    new Country { Id = 5, Name = "Argentina" }
};
        return countries;

    }
}

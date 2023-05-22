using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Seeds;

public class CitySeed
{
  
    public static List<City> GetCities()
    {
        List<City> cities = new List<City>
        {
            new City { Id = 1, Name = "Los Angeles", StateId = 1},
            new City { Id = 2, Name = "San Francisco", StateId = 1},
            new City { Id = 3, Name = "Houston", StateId = 2},
            new City { Id = 4, Name = "Austin", StateId = 2},
            new City { Id = 5, Name = "Toronto", StateId = 3},
            new City { Id = 6, Name = "Ottawa", StateId = 4},
            new City { Id = 7, Name = "Guadalajara", StateId = 5},
            new City { Id = 8, Name = "Monterrey", StateId = 6},
            new City { Id = 9, Name = "Los Angeles", StateId = 7},
            new City { Id = 10, Name = "Sao Paulo", StateId = 7},
            new City { Id = 11, Name = "Rio de Janeiro", StateId = 8},
            new City { Id = 12, Name = "Buenos Aires", StateId = 9},
            new City { Id = 14, Name = "Mendoza", StateId = 9},
            new City { Id = 15, Name = "Rosario", StateId = 9},
            new City { Id = 16, Name = "La Plata", StateId = 9},
            new City { Id = 17, Name = "Salta", StateId = 9},
            new City { Id = 18, Name = "Cali", StateId = 10},
            new City { Id = 19, Name = "Medellin", StateId = 10},
            new City { Id = 20, Name = "Bogota", StateId = 10},
            new City { Id = 21, Name = "Caracas", StateId = 11 },
            new City { Id = 22, Name = "Maracaibo", StateId = 11 },
            new City { Id = 23, Name = "Valencia", StateId = 11 }

        };
        return cities;

    }
}

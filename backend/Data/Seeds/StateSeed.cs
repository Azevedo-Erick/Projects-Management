using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectsManagement.Models;

namespace ProjectsManagement.Data.Seeds;

public class StateSeed
{

    public static List<State> GetStates()
    {
        List<State> states = new List<State>
        {
            new State { Id = 1, Name = "California", CountryId = 1,  },
            new State { Id = 2, Name = "Texas", CountryId = 1,  },
            new State { Id = 3, Name = "Ontario", CountryId = 2,  },
            new State { Id = 4, Name = "Quebec", CountryId = 2,  },
            new State { Id = 5, Name = "Jalisco", CountryId = 3,  },
            new State { Id = 6, Name = "Nuevo Leon", CountryId = 3,  },
            new State { Id = 7, Name = "Sao Paulo", CountryId = 4,  },
            new State { Id = 8, Name = "Rio de Janeiro", CountryId = 4,  },
            new State { Id = 9, Name = "Buenos Aires", CountryId = 5,  },
            new State { Id = 10, Name = "Cordoba", CountryId = 5,  }
        };
        return states;

    }
}

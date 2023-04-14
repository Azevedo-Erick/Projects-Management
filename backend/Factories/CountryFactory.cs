using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Models;

namespace ProjectsManagement.Factories;

public static class CountryFactory
{
    public static ResponseCountryDto FromModelToDto(Country country)
    {
        return new ResponseCountryDto(country.Id, country.Name);
    }
    public static Country FromDtoToModel(CreateCountryDto dto)
    {
        return new Country(dto.Name);
    }


}

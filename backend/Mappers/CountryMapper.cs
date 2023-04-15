using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public static class CountryMapper
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

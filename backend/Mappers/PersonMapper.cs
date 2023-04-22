using ProjectsManagement.Dtos.Person;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers
{
    public class PersonMapper
    {
        public static ResponsePersonDto FromModelToDto(Person model)
        {
            return new ResponsePersonDto();
        }
        public static Person FromDtoToModel(CreatePersonDto dto)
        {
            return new Person();
        }
        public PersonMapper()
        {
            // constructor logic here
        }

        // class members here
    }
}
using ProjectsManagement.Dtos.Person;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers
{
    public class PersonMapper
    {
        public static ResponsePersonDto FromModelToDto(Person model)
        {
            return new ResponsePersonDto
            {
                Addresses = new(),
                Contacts = new(),
                Email = model.Email,
                Name = model.Name,
                ProfileImage = "",
                DateOfBirth = model.DateOfBirth
            };
        }
        public static Person FromDtoToModel(CreatePersonDto dto)
        {
            return new Person
            {
                Addresses = new(),
                Contacts = new(),
                Email = dto.Email,
                Name = dto.Name,
                PasswordHash = "",
                ProfileImage = "",
                DateOfBirth = dto.DateOfBirth
            };
        }
        public PersonMapper()
        {
            // constructor logic here
        }

        // class members here
    }
}
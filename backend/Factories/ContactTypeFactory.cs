using ProjectsManagement.Dtos.ContactType;
using ProjectsManagement.Models;

namespace ProjectsManagement.Factories;

public static class ContactTypeFactory
{

    public static ResponseContactTypeDto FromModelToDto(ContactType model)
    {
        return new ResponseContactTypeDto(model.Name);
    }
    public static ContactType FromDtoToModel(CreateContactTypeDto dto)
    {
        return new ContactType(dto.Name);
    }
}

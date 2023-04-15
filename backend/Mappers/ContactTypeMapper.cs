using ProjectsManagement.Dtos.ContactType;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public static class ContactTypeMapper
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

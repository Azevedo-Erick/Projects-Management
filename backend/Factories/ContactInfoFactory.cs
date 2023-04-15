using ProjectsManagement.Dtos.ContactInfo;
using ProjectsManagement.Dtos.ContactType;
using ProjectsManagement.Models;

namespace ProjectsManagement.Factories;

public static class ContactInfoFactory
{

    public static ResponseContactInfoDto FromModelToDto(ContactInfo model)
    {
        return new ResponseContactInfoDto(model.Value, model.Type.Name);
    }
    public static ContactInfo FromDtoToModel(CreateContactInfoDto dto)
    {
        return new ContactInfo(dto.Value, dto.ContactTypeId);
    }
}


using ProjectsManagement.Dtos.Role;
using ProjectsManagement.Dtos.Task;
using ProjectsManagement.Dtos.Ticket;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public static class TicketMapper
{
    public static ResponseTicketDto FromModelToDto(Ticket model)
    {
        return new ResponseTicketDto();
    }
    public static Ticket FromDtoToModel(CreateTicketDto dto)
    {
        return new Ticket();
    }
}

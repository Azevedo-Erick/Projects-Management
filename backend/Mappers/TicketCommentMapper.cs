
using ProjectsManagement.Dtos.Role;
using ProjectsManagement.Dtos.Task;
using ProjectsManagement.Dtos.Ticket;
using ProjectsManagement.Dtos.TicketComment;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers;

public static class TicketCommentMapper
{
    public static ResponseTicketCommentDto FromModelToDto(TicketComment model)
    {
        return new ResponseTicketCommentDto();
    }
    public static TicketComment FromDtoToModel(CreateTicketCommentDto dto)
    {
        return new TicketComment();
    }
}

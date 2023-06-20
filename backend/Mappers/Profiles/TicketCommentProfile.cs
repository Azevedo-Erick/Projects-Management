using AutoMapper;
using ProjectsManagement.Dtos.TicketComment;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class TicketCommentProfile : Profile
{
    public TicketCommentProfile()
    {
        CreateMap<CreateTicketCommentDto, TicketComment>();
        CreateMap<TicketComment, ResponseTicketCommentDto>();
    }

    // class members here
}

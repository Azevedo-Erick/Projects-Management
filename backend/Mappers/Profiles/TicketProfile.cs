using AutoMapper;
using ProjectsManagement.Dtos.Ticket;
using ProjectsManagement.Models;

namespace ProjectsManagement.Mappers.Profiles;

public class TicketProfile : Profile
{
    public TicketProfile()
    {
        CreateMap<CreateTicketDto, Ticket>();
        CreateMap<Ticket, ResponseTicketDto>();

    }

    // class members here
}

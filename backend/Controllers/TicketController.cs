using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using AutoMapper;
using ProjectsManagement.Dtos.Ticket;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class TicketController : ControllerBase
{
    private readonly ProjectsManagementContext _context;
    private readonly IMapper _mapper;
    public TicketController(ProjectsManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    [AllowAnonymous]
    [HttpGet("/v1/tickets")]
    public async Task<IActionResult> Get()
    {
        var data = await _context.Tickets.Include(x => x.Author).Include(x => x.Project).ToListAsync();
        return StatusCode(200, new BaseResponseDto<ResponseTicketDto>(data.ConvertAll(TicketMapper.FromModelToDto)));
    }

    [HttpGet("/v1/tickets/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Tickets.Include(x => x.Author).Include(x => x.Project).Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }
        return StatusCode(200, new BaseResponseDto<ResponseTicketDto>(TicketMapper.FromModelToDto(data)));
    }

    [HttpPost("/v1/tickets")]
    public async Task<IActionResult> Post(CreateTicketDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }
        var author = await _context.Persons.Where(x => x.Id == dto.AuthorId).FirstOrDefaultAsync();
        if (author == null)
        {
            return StatusCode(400);
        }
        var project = await _context.Projects.Where(x => x.Id == dto.ProjectId).FirstOrDefaultAsync();
        if (project == null)
        {
            return StatusCode(400);
        }
        var data = TicketMapper.FromDtoToModel(dto);

        data.Author = author;
        data.Project = project;
        _context.Tickets.Add(data);
        _context.SaveChanges();
        return StatusCode(201, new BaseResponseDto<ResponseTicketDto>(TicketMapper.FromModelToDto(data)));
    }

    [HttpPatch("/v1/tickets/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateTicketDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }
        var model = await _context.Tickets.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (model == null)
        {
            return StatusCode(400);
        }
        var data = TicketMapper.FromDtoToModel(dto);

        if (model.AuthorId != model.AuthorId)
        {
            var author = await _context.Persons.Where(x => x.Id == model.AuthorId).FirstOrDefaultAsync();
            if (author == null)
            {
                return StatusCode(400);
            }
            model.Author = author;
        }
        if (model.ProjectId != model.ProjectId)
        {
            var project = await _context.Projects.Where(x => x.Id == model.ProjectId).FirstOrDefaultAsync();
            if (project == null)
            {
                return StatusCode(400);
            }
            model.Project = project;
        }

        _context.Tickets.Update(model);
        _context.SaveChanges();
        return StatusCode(201, new BaseResponseDto<ResponseTicketDto>(TicketMapper.FromModelToDto(model)));
    }

    [HttpDelete("/v1/tickets/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var model = await _context.Tickets.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (model == null)
        {
            return StatusCode(400);
        }
        _context.Tickets.Remove(model);
        _context.SaveChanges();
        return StatusCode(201, new BaseResponseDto<ResponseTicketDto>(TicketMapper.FromModelToDto(model)));

    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Ticket;
using ProjectsManagement.Dtos.TicketComment;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class TicketCommentController : ControllerBase
{
    private readonly ProjectsManagementContext _context;
    public TicketCommentController(ProjectsManagementContext context)
    {
        _context = context;
    }
    [AllowAnonymous]
    [HttpGet("/v1/ticket-comments")]
    public async Task<IActionResult> Get()
    {
        var data = await _context.TicketComment.Include(x => x.Author).Include(x => x.Ticket).ToListAsync();
        return StatusCode(200, new BaseResponseDto<List<ResponseTicketCommentDto>>(data.ConvertAll(TicketCommentMapper.FromModelToDto)));
    }


    [HttpGet("/v1/ticket-comments/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.TicketComment.Include(x => x.Author).Include(x => x.Ticket).Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }
        return StatusCode(200, new BaseResponseDto<ResponseTicketCommentDto>(TicketCommentMapper.FromModelToDto(data)));

    }



    [HttpPost("/v1/ticket-comments")]
    public async Task<IActionResult> Post(CreateTicketCommentDto dto)
    {

        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }
        var model = TicketCommentMapper.FromDtoToModel(dto);
        var author = await _context.Persons.Where(x => x.Id == dto.AuthorId).FirstOrDefaultAsync();
        if (author == null)
        {
            return StatusCode(400);
        }
        var ticket = await _context.Tickets.Where(x => x.Id == dto.TicketId).FirstOrDefaultAsync();
        if (ticket == null)
        {
            return StatusCode(400);
        }
        model.Ticket = ticket;
        model.Author = author;
        _context.TicketComment.Add(model);
        _context.SaveChanges();
        return StatusCode(200, new BaseResponseDto<ResponseTicketCommentDto>(TicketCommentMapper.FromModelToDto(model)));

    }



    [HttpPatch("/v1/ticket-comments/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateTicketCommentDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }
        var model = await _context.TicketComment.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (model == null)
        {
            return StatusCode(400);
        }
        var data = TicketCommentMapper.FromDtoToModel(dto);

        if (model.AuhtorId != data.AuhtorId)
        {
            var author = await _context.Persons.Where(x => x.Id == dto.AuthorId).FirstOrDefaultAsync();
            if (author == null)
            {
                return StatusCode(400);
            }
            model.Author = author;
        }
        if (model.TicketId != data.TicketId)
        {
            var ticket = await _context.Tickets.Where(x => x.Id == dto.TicketId).FirstOrDefaultAsync();
            if (ticket == null)
            {
                return StatusCode(400);
            }
            model.Ticket = ticket;
        }
        _context.TicketComment.Update(model);
        _context.SaveChanges();
        return StatusCode(200, new BaseResponseDto<ResponseTicketCommentDto>(TicketCommentMapper.FromModelToDto(model)));
    }



    [HttpDelete("/v1/ticket-comments/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var model = await _context.TicketComment.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (model == null)
        {
            return StatusCode(400);
        }
        _context.TicketComment.Remove(model);
        _context.SaveChanges();
        return StatusCode(200, new BaseResponseDto<ResponseTicketCommentDto>());

    }

}
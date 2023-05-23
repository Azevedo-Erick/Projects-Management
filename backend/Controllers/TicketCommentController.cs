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
    public async Task<IActionResult> Post(CreateTicketCommentDto dto) { return null; }



    [HttpPatch("/v1/ticket-comments/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TicketComment dto) { return null; }



    [HttpDelete("/v1/ticket-comments/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
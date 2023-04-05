using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class TicketCommentController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/ticket-comments")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/ticket-comments/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/ticket-comments")]
    public async Task<IActionResult> Post(TicketComment dto) { return null; }



    [HttpPatch("/v1/ticket-comments/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TicketComment dto) { return null; }



    [HttpDelete("/v1/ticket-comments/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
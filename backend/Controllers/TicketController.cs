using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class TicketController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/tickets")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/tickets/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/tickets")]
    public async Task<IActionResult> Post(Ticket dto) { return null; }



    [HttpPatch("/v1/tickets/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Ticket dto) { return null; }



    [HttpDelete("/v1/tickets/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
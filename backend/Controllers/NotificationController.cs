using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class NotificationController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/notifications")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/notifications/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/notifications")]
    public async Task<IActionResult> Post(Notification dto) { return null; }



    [HttpPatch("/v1/notifications/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Notification dto) { return null; }



    [HttpDelete("/v1/notifications/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
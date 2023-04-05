using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class NotificationTypeController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/notification-types")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/notification-types/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/notification-types")]
    public async Task<IActionResult> Post(NotificationType dto) { return null; }



    [HttpPatch("/v1/notification-types/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] NotificationType dto) { return null; }



    [HttpDelete("/v1/notification-types/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
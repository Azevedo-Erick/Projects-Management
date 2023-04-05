using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class ActivityLogController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/activities-logs")]
    public async Task<IActionResult> Get()
    {
        return null;
    }

    [HttpGet("/v1/activities-logs/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        return null;

    }


    [HttpPost("/v1/activities-logs")]
    public async Task<IActionResult> Post(ActivityLog dto)
    {
        return null;

    }


    [HttpPatch("/v1/activities-logs/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ActivityLog dto)
    {
        return null;

    }


    [HttpDelete("/v1/activities-logs/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return null;

    }
}
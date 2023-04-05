using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class ActivityTypeController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/activities-types")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/activities-types/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/activities-types")]
    public async Task<IActionResult> Post(ActivityType dto) { return null; }



    [HttpPatch("/v1/activities-types/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ActivityType dto) { return null; }



    [HttpDelete("/v1/activities-types/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class TaskCommentController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/tasks")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/tasks/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/tasks")]
    public async Task<IActionResult> Post(Models.Task dto) { return null; }



    [HttpPatch("/v1/tasks/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Models.Task dto) { return null; }



    [HttpDelete("/v1/tasks/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
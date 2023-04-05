using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class ProjectController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/projects")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/projects/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/projects")]
    public async Task<IActionResult> Post(Project dto) { return null; }



    [HttpPatch("/v1/projects/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Project dto) { return null; }



    [HttpDelete("/v1/projects/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
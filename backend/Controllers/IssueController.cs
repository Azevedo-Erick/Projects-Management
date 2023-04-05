using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class IssueController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/issues")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/issues/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/issues")]
    public async Task<IActionResult> Post(Issue dto) { return null; }



    [HttpPatch("/v1/issues/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Issue dto) { return null; }



    [HttpDelete("/v1/issues/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
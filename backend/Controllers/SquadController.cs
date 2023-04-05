using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class SquadController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/squads")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/squads/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/squads")]
    public async Task<IActionResult> Post(Squad dto) { return null; }



    [HttpPatch("/v1/squads/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Squad dto) { return null; }



    [HttpDelete("/v1/squads/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
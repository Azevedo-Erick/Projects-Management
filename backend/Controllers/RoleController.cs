using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class RoleController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/roles")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/roles/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/roles")]
    public async Task<IActionResult> Post(Role dto) { return null; }



    [HttpPatch("/v1/roles/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Role dto) { return null; }



    [HttpDelete("/v1/roles/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class StateController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/states")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/states/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/states")]
    public async Task<IActionResult> Post(State dto) { return null; }



    [HttpPatch("/v1/states/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] State dto) { return null; }



    [HttpDelete("/v1/states/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
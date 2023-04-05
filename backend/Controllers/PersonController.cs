using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class PersonController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/persons")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/persons/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/persons")]
    public async Task<IActionResult> Post(Person dto) { return null; }



    [HttpPatch("/v1/persons/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Person dto) { return null; }



    [HttpDelete("/v1/persons/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
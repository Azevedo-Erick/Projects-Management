using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Data;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class CityController : ControllerBase
{
    ProjectsManagementContext Context;

    CityController(ProjectsManagementContext context)
    {
        Context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/cities")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/cities/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/cities")]
    public async Task<IActionResult> Post(City dto) { return null; }



    [HttpPatch("/v1/cities/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] City dto) { return null; }



    [HttpDelete("/v1/cities/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
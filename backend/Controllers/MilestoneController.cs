using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class MilestoneController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/milestones")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/milestones/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/milestones")]
    public async Task<IActionResult> Post(Milestone dto) { return null; }



    [HttpPatch("/v1/milestones/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Milestone dto) { return null; }



    [HttpDelete("/v1/milestones/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
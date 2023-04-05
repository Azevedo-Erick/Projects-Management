using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class StakeholderController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/stakeholders")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/stakeholders/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/stakeholders")]
    public async Task<IActionResult> Post(Stakeholder dto) { return null; }



    [HttpPatch("/v1/stakeholders/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Stakeholder dto) { return null; }



    [HttpDelete("/v1/stakeholders/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
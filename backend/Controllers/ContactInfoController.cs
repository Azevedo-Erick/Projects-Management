using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class ContactInfoController : ControllerBase
{

    [AllowAnonymous]
    [HttpGet("/v1/contact-infos")]
    public async Task<IActionResult> Get() { return null; }


    [HttpGet("/v1/contact-infos/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id) { return null; }



    [HttpPost("/v1/contact-infos")]
    public async Task<IActionResult> Post(ContactInfo dto) { return null; }



    [HttpPatch("/v1/contact-infos/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] ContactInfo dto) { return null; }



    [HttpDelete("/v1/contact-infos/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
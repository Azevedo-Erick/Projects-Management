using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Role;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class RoleController : ControllerBase
{

    private readonly ProjectsManagementContext _context;

    public RoleController(ProjectsManagementContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/roles")]
    public async Task<IActionResult> Get()
    {
        var data = await _context.Roles.ToListAsync();
        return StatusCode(200, new BaseResponseDto<ResponseRoleDto>(data.Select(RoleMapper.FromModelToDto).ToList()));

    }


    [HttpGet("/v1/roles/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Roles.Where(x => x.Id == id).Include(x => x.Permissions).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseRoleDto>());
        }
        return StatusCode(200, new BaseResponseDto<ResponseRoleDto>(RoleMapper.FromModelToDto(data)));
    }



    [HttpPost("/v1/roles")]
    public async Task<IActionResult> Post(CreateRoleDto dto)
    {
        if (!ModelState.IsValid) { }


        return StatusCode(200, new BaseResponseDto<ResponseRoleDto>());

    }



    [HttpPatch("/v1/roles/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Role dto) { return null; }



    [HttpDelete("/v1/roles/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id) { return null; }

}
using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.ActivityLog;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class ActivityLogController : ControllerBase
{
    private readonly ProjectsManagementContext _context;

    public ActivityLogController(ProjectsManagementContext context)
    {
        this._context = context;
    }
    [AllowAnonymous]
    [HttpGet("/v1/activities-logs")]
    public async Task<IActionResult> Get([FromQuery] ActivityLogQueryParams queryParams)
    {
        var data = await _context.ActivityLogs.AsQueryable().Apply(queryParams).ToListAsync();
        return StatusCode(200, new BaseResponseDto<ResponseActivityLogDto>(data.Select(ActivityLogMapper.FromModelToDto).ToList()));
    }

    [HttpGet("/v1/activities-logs/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.ActivityLogs.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(400);
        }

        return StatusCode(200, new BaseResponseDto<ResponseActivityLogDto>(ActivityLogMapper.FromModelToDto(data)));

    }


    [HttpDelete("/v1/activities-logs/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var data = await _context.ActivityLogs.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }

        _context.ActivityLogs.Remove(data);
        await _context.SaveChangesAsync();
        return StatusCode(200, new BaseResponseDto<ResponseActivityLogDto>());

    }
}
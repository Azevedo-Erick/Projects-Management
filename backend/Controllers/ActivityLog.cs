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


    [HttpPost("/v1/activities-logs")]
    public async Task<IActionResult> Post(CreateActivityLogDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }

        var person = new Person();

        var activityType = await _context.ActivityTypes.Where(x => x.Id == dto.ActivityTypeId).FirstOrDefaultAsync();

        if (activityType == null)
        {
            return StatusCode(400);
        }

        var data = ActivityLogMapper.FromDtoToModel(dto);
        data.ActivityType = activityType;
        data.Person = person;
        _context.ActivityLogs.Add(data);
        await _context.SaveChangesAsync();
        return StatusCode(200, new BaseResponseDto<ResponseActivityLogDto>(ActivityLogMapper.FromModelToDto(data)));

    }


    [HttpPatch("/v1/activities-logs/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateActivityLogDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }

        var data = await _context.ActivityLogs.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(400);
        }

        var serializedData = ActivityLogMapper.FromDtoToModel(dto);

        if (dto.ActivityTypeId != data.ActivityTypeId)
        {
            var activityType =
                await _context.ActivityTypes.Where(x => x.Id == dto.ActivityTypeId).FirstOrDefaultAsync();

            if (activityType == null)
            {
                return StatusCode(400);
            }

            data.ActivityType = activityType;
        }

        if (dto.PersonId != data.PersonId)
        {
            Person? person = new Person();

            if (person == null)
            {
                return StatusCode(400);
            }
            data.Person = person;

        }

        if (dto.Description == data.Description)
        {
            data.Description = dto.Description;
        }

        _context.ActivityLogs.Update(data);
        await _context.SaveChangesAsync();

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
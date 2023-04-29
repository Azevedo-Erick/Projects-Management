using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.ActivityLog;
using ProjectsManagement.Dtos.ActivityType;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class ActivityTypeController : ControllerBase
{

    private readonly ProjectsManagementContext _context;

    public ActivityTypeController(ProjectsManagementContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/activities-types")]
    public async Task<IActionResult> Get([FromQuery] ActivityTypeQueryParams queryParams)
    {
        var data = await _context.ActivityTypes.AsQueryable().Apply(queryParams).AsNoTracking().ToListAsync();
        return StatusCode(200, new BaseResponseDto<ResponseActivityTypeDto>(data.Select(ActivityTypeMapper.FromModelToDto).ToList()));
    }


    [HttpGet("/v1/activities-types/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.ActivityTypes.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }
        return StatusCode(200, new BaseResponseDto<ResponseActivityTypeDto>(ActivityTypeMapper.FromModelToDto(data)));
    }



    [HttpPost("/v1/activities-types")]
    public async Task<IActionResult> Post(CreateActivityTypeDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }

        var data = ActivityTypeMapper.FromDtoToModel(dto);
        _context.ActivityTypes.Add(data);
        await _context.SaveChangesAsync();
        return StatusCode(200, new BaseResponseDto<ResponseActivityTypeDto>(ActivityTypeMapper.FromModelToDto(data)));
    }



    [HttpPatch("/v1/activities-types/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateActivityTypeDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }


        var data = await _context.ActivityTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }
        var serializedData = ActivityTypeMapper.FromDtoToModel(dto);

        if (serializedData.Name != data.Name)
        {
            data.Name = serializedData.Name;
        }

        _context.ActivityTypes.Update(data);
        await _context.SaveChangesAsync();
        return StatusCode(200, new BaseResponseDto<ResponseActivityTypeDto>(ActivityTypeMapper.FromModelToDto(data)));
    }



    [HttpDelete("/v1/activities-types/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var data = await _context.ActivityTypes.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }
        _context.ActivityTypes.Remove(data);
        await _context.SaveChangesAsync();
        return StatusCode(200, new BaseResponseDto<ResponseActivityTypeDto>());

    }

}
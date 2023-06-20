using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Data.Mappings;
using AutoMapper;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.NotificationType;
using ProjectsManagement.Extensions;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
//[Authorize]
public class NotificationTypeController : ControllerBase
{
    private readonly ProjectsManagementContext _context;

    private readonly IMapper _mapper;
    public NotificationTypeController(ProjectsManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }


    [AllowAnonymous]
    [HttpGet("/v1/notification-types")]
    public async Task<IActionResult> Get([FromQuery] NotificationTypeQueryParams queryParams)
    {
        var data = await _context.NotificationTypes.AsQueryable().Apply(queryParams).AsNoTracking().ToListAsync();
        return StatusCode(200, new BaseResponseDto<ResponseNotificationTypeDto>(data.Select(x => NotificationTypeMapper.FromModelToDto(x)).ToList()));
    }


    [HttpGet("/v1/notification-types/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.NotificationTypes.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }
        return StatusCode(200, new BaseResponseDto<ResponseNotificationTypeDto>(NotificationTypeMapper.FromModelToDto(data)));
    }



    [HttpPost("/v1/notification-types")]
    [AllowAnonymous]
    public async Task<IActionResult> Post(CreateNotificationTypeDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400, new BaseResponseDto<ResponseNotificationTypeDto>(ModelState.GetErrors()));

        }

        var data = NotificationTypeMapper.FromDtoToModel(dto);

        _context.NotificationTypes.Add(data);
        await _context.SaveChangesAsync();

        return StatusCode(201,
            new BaseResponseDto<ResponseNotificationTypeDto>(NotificationTypeMapper.FromModelToDto(data)));
    }



    [HttpPatch("/v1/notification-types/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateNotificationTypeDto dto)
    {
        if (!ModelState.IsValid) { }

        var data = await _context.NotificationTypes.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(400);
        }

        var serializedData = NotificationTypeMapper.FromDtoToModel(dto);

        if (serializedData.Name != data.Name)
        {
            data.Name = serializedData.Name;
        }

        _context.NotificationTypes.Update(data);
        await _context.SaveChangesAsync();
        return StatusCode(200, new BaseResponseDto<ResponseNotificationTypeDto>(NotificationTypeMapper.FromModelToDto(data)));
    }



    [HttpDelete("/v1/notification-types/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var data = await _context.NotificationTypes.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(400);
        }

        _context.NotificationTypes.Remove(data);
        _context.SaveChangesAsync();
        return StatusCode(200, new BaseResponseDto<ResponseNotificationTypeDto>());

    }

}
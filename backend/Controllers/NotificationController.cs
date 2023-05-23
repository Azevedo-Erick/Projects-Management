using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Notification;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
//[Authorize]
public class NotificationController : ControllerBase
{
    private readonly ProjectsManagementContext _context;

    public NotificationController(ProjectsManagementContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/notifications")]
    public async Task<IActionResult> Get([FromQuery] NotificationQueryParams queryParams)
    {
        var data = await _context.Notifications.AsQueryable().Apply(queryParams).Include(x => x.Recipient).Include(x => x.Type).AsNoTracking().ToListAsync();
        return StatusCode(200, new BaseResponseDto<ResponseNotificationDto>(data.ConvertAll(NotificationMapper.FromModelToDto)));
    }

    [HttpGet("/v1/notifications/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Notifications.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);
        }
        return StatusCode(200, new BaseResponseDto<ResponseNotificationDto>(NotificationMapper.FromModelToDto(data)));
    }

    [HttpPost("/v1/notifications")]
    public async Task<IActionResult> Post(CreateNotificationDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }

        var data = NotificationMapper.FromDtoToModel(dto);
        var type = await _context.NotificationTypes.Where(x => x.Id == data.TypeId).FirstOrDefaultAsync();
        if (type == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseNotificationDto>("O tipo informado não foi encontrado"));
        }
        var person = await _context.Persons.Where(x => x.Id == data.RecipientId).FirstOrDefaultAsync();

        if (person == null)
        {
            return StatusCode(400, new BaseResponseDto<ResponseNotificationDto>("A pessoa informada não foi encontrada"));
        }

        data.Type = type;
        data.Recipient = person;

        _context.Notifications.Add(data);
        await _context.SaveChangesAsync();
        return StatusCode(201, new BaseResponseDto<ResponseNotificationDto>(NotificationMapper.FromModelToDto(data)));
    }

    [HttpPatch("/v1/notifications/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateNotificationDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(400);
        }

        var data = await _context.Notifications.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(400);
        }

        var serializedData = NotificationMapper.FromDtoToModel(dto);

        if (data.TypeId != serializedData.TypeId)
        {
            var type = await _context.NotificationTypes.Where(x => x.Id == serializedData.TypeId).FirstOrDefaultAsync();
            if (type == null)
            {
                return StatusCode(400);
            }
            data.Type = type;
        }

        if (data.RecipientId != serializedData.RecipientId)
        {
            Person person = null;

            if (person == null)
            {
                return StatusCode(400);
            }
            data.Recipient = person;
        }

        if (data.IsRead != serializedData.IsRead)
        {
            data.IsRead = serializedData.IsRead;

        }

        if (data.Message != serializedData.Message)
        {
            data.Message = serializedData.Message;
        }

        _context.Notifications.Update(data);
        await _context.SaveChangesAsync();
        return StatusCode(200, new BaseResponseDto<ResponseNotificationDto>(NotificationMapper.FromModelToDto(data)));

    }



    [HttpDelete("/v1/notifications/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var data = await _context.Notifications.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(400);

        }
        return StatusCode(200, new BaseResponseDto<ResponseNotificationDto>());

    }

}
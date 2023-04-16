using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.ContactType;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class ContactTypeController : ControllerBase
{

    private readonly ProjectsManagementContext _context;

    public ContactTypeController(ProjectsManagementContext context)
    {
        this._context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/contact-types")]
    public async Task<IActionResult> Get([FromQuery] ContactTypeQueryParams queryParams)
    {
        var data = await _context.ContactTypes.AsQueryable().Apply(queryParams).AsNoTracking().ToListAsync();
        return StatusCode(
             200,
             new BaseResponseDto<ResponseContactTypeDto>(
                 data.Select(
                         x => ContactTypeMapper.FromModelToDto(x)
                     ).ToList()
                 )
             );
    }


    [HttpGet("/v1/contact-types/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.ContactTypes.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(
            400
            );
        }
        return StatusCode(
            200,
            new BaseResponseDto<ResponseContactTypeDto>(ContactTypeMapper.FromModelToDto(data)

                )
            );
    }



    [HttpPost("/v1/contact-types")]
    public async Task<IActionResult> Post(CreateContactTypeDto dto)
    {
        if (!ModelState.IsValid) { }

        var data = ContactTypeMapper.FromDtoToModel(dto);


        await _context.ContactTypes.AddAsync(data);
        _context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseContactTypeDto>(
                   ContactTypeMapper.FromModelToDto(data)
               )
           );
    }



    [HttpPatch("/v1/contact-types/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateContactTypeDto dto)
    {
        if (!ModelState.IsValid) { }

        var data = await _context.ContactTypes.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(400);
        }

        var serializedData = ContactTypeMapper.FromDtoToModel(dto);

        if (data.Name != serializedData.Name)
        {
            data.Name = serializedData.Name;
        }

        _context.ContactTypes.Update(data);
        _context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseContactTypeDto>(
                   ContactTypeMapper.FromModelToDto(data)
               )
           );
    }



    [HttpDelete("/v1/contact-types/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {

        var data = await _context.ContactTypes.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(400);
        }
        _context.ContactTypes.Remove(data);
        _context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseContactTypeDto>(
               )
           );
    }

}
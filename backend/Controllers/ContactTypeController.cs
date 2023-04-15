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

    ProjectsManagementContext Context;

    public ContactTypeController(ProjectsManagementContext context)
    {
        this.Context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/contact-types")]
    public async Task<IActionResult> Get([FromQuery] ContactTypeQueryParams queryParams)
    {
        var data = await Context.ContactTypes.AsQueryable().Apply(queryParams).AsNoTracking().ToListAsync();
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
        var data = await Context.ContactTypes.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
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


        await Context.ContactTypes.AddAsync(data);
        Context.SaveChanges();

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

        var data = await Context.ContactTypes.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(400);
        }

        var serializedData = ContactTypeMapper.FromDtoToModel(dto);

        if (data.Name != serializedData.Name)
        {
            data.Name = serializedData.Name;
        }

        Context.ContactTypes.Update(data);
        Context.SaveChanges();

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

        var data = await Context.ContactTypes.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(400);
        }
        Context.ContactTypes.Remove(data);
        Context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseContactTypeDto>(
               )
           );
    }

}
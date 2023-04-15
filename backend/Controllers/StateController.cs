using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Country;
using ProjectsManagement.Dtos.State;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class StateController : ControllerBase
{

    ProjectsManagementContext Context;

    StateController(ProjectsManagementContext context)
    {
        Context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/states")]
    public async Task<IActionResult> Get([FromQuery] StateQueryParams queryParams)
    {
        var data = await Context.States.AsQueryable().Apply(queryParams)
            .Include(x => x.Country).AsNoTracking().ToListAsync();

        return StatusCode(
            200,
            new BaseResponseDto<ResponseStateDto>(
                data.Select(
                        x => StateMapper.FromModelToDto(x)
                    ).ToList()
                )
            );
    }


    [HttpGet("/v1/states/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await Context.States.Where(x => x.Id == id)
        .Include(x => x.Country)
        .AsNoTracking()
        .FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(
            400);
        }
        return StatusCode(
           200,
           new BaseResponseDto<ResponseStateDto>(
                   StateMapper.FromModelToDto(data)
               )
           );
    }



    [HttpPost("/v1/states")]
    public async Task<IActionResult> Post(CreateStateDto dto)
    {
        if (!ModelState.IsValid) { }
        var data = StateMapper.FromDtoToModel(dto);
        //data.State = ;
        await Context.States.AddAsync(data);
        Context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseStateDto>(
                   StateMapper.FromModelToDto(data)
               )
           );

    }



    [HttpPatch("/v1/states/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateStateDto dto)
    {
        if (!ModelState.IsValid) { }
        var element = await Context.States.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }
        var data = StateMapper.FromDtoToModel(dto);
        element.Name = data.Name;
        element.Country = data.Country;

        Context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseStateDto>(
                   StateMapper.FromModelToDto(element)
               )
           );

    }



    [HttpDelete("/v1/states/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var element = await Context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }
        Context.Countries.Remove(element);
        return StatusCode(
           200,
           new BaseResponseDto<ResponseStateDto>()
           );

    }

}
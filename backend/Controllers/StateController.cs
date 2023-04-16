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

    private readonly ProjectsManagementContext _context;

    StateController(ProjectsManagementContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/states")]
    public async Task<IActionResult> Get([FromQuery] StateQueryParams queryParams)
    {
        var data = await _context.States.AsQueryable().Apply(queryParams)
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
        var data = await _context.States.Where(x => x.Id == id)
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
        await _context.States.AddAsync(data);
        _context.SaveChanges();

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
        var element = await _context.States.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }
        var data = StateMapper.FromDtoToModel(dto);
        element.Name = data.Name;
        element.Country = data.Country;

        _context.SaveChanges();

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
        var element = await _context.Countries.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }
        _context.Countries.Remove(element);
        return StatusCode(
           200,
           new BaseResponseDto<ResponseStateDto>()
           );

    }

}
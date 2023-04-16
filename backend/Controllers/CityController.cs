using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.City;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class CityController : ControllerBase
{
    private readonly ProjectsManagementContext _context;

    CityController(ProjectsManagementContext context)
    {
        _context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/cities")]
    public async Task<IActionResult> Get([FromQuery] CityQueryParams queryParams)
    {
        var data = await _context.Cities.AsQueryable().Apply(queryParams)
                .Include(x => x.State)
                    .ThenInclude(x => x.Country)
                .AsNoTracking()
                .ToListAsync();

        return StatusCode(
            200,
            new BaseResponseDto<ResponseCityDto>(
                data.Select(
                        x => CityMapper.FromModelToDto(x)
                    ).ToList()
                )
            );

    }


    [HttpGet("/v1/cities/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await _context.Cities.Where(x => x.Id == id)
                    .Include(x => x.State)
                    .ThenInclude(x => x.Country)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(
            400);
        }

        return StatusCode(
            200,
            new BaseResponseDto<ResponseCityDto>(
                    CityMapper.FromModelToDto(data)
                )
            );

    }



    [HttpPost("/v1/cities")]
    public async Task<IActionResult> Post(CreateCityDto dto)
    {
        if (!ModelState.IsValid) { }
        var data = CityMapper.FromDtoToModel(dto);
        //data.State = ;
        await _context.Cities.AddAsync(data);
        _context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseCityDto>(
                   CityMapper.FromModelToDto(data)
               )
           );
    }



    [HttpPatch("/v1/cities/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateCityDto dto)
    {
        if (!ModelState.IsValid) { }
        var element = await _context.Cities.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }
        var data = CityMapper.FromDtoToModel(dto);
        element.Name = data.Name;
        element.State = data.State;

        _context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseCityDto>(
                   CityMapper.FromModelToDto(element)
               )
           );
    }



    [HttpDelete("/v1/cities/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var element = await _context.Cities.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }
        _context.Cities.Remove(element);
        return StatusCode(
           200,
           new BaseResponseDto<ResponseCityDto>()
           );
    }

}
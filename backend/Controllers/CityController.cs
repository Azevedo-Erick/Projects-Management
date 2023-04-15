using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.City;
using ProjectsManagement.Factories;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class CityController : ControllerBase
{
    ProjectsManagementContext Context;

    CityController(ProjectsManagementContext context)
    {
        Context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/cities")]
    public async Task<IActionResult> Get([FromQuery] CityQueryParams queryParams)
    {
        var data = await Context.Cities.AsQueryable().Apply(queryParams)
                .Include(x => x.State)
                    .ThenInclude(x => x.Country)
                .AsNoTracking()
                .ToListAsync();

        return StatusCode(
            200,
            new BaseResponseDto<ResponseCityDto>(
                data.Select(
                        x => CityFactory.FromModelToDto(x)
                    ).ToList()
                )
            );

    }


    [HttpGet("/v1/cities/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await Context.Cities.Where(x => x.Id == id)
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
                    CityFactory.FromModelToDto(data)
                )
            );

    }



    [HttpPost("/v1/cities")]
    public async Task<IActionResult> Post(CreateCityDto dto)
    {
        if (!ModelState.IsValid) { }
        var data = CityFactory.FromDtoToModel(dto);
        //data.State = ;
        await Context.Cities.AddAsync(data);
        Context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseCityDto>(
                   CityFactory.FromModelToDto(data)
               )
           );
    }



    [HttpPatch("/v1/cities/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateCityDto dto)
    {
        if (!ModelState.IsValid) { }
        var element = await Context.Cities.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }
        var data = CityFactory.FromDtoToModel(dto);
        element.Name = data.Name;
        element.State = data.State;

        Context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseCityDto>(
                   CityFactory.FromModelToDto(element)
               )
           );
    }



    [HttpDelete("/v1/cities/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var element = await Context.Cities.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (element == null)
        {
            return StatusCode(
            400);
        }
        Context.Cities.Remove(element);
        return StatusCode(
           200,
           new BaseResponseDto<ResponseCityDto>()
           );
    }

}
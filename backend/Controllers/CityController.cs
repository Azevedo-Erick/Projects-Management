using AspNetCore.IQueryable.Extensions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.City;
using ProjectsManagement.Extensions;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
//[Authorize]
public class CityController : ControllerBase
{
    private readonly ProjectsManagementContext _context;
    private readonly IMapper _mapper;

    public CityController(ProjectsManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [AllowAnonymous]
    [HttpGet("/v1/cities")]
    public async Task<IActionResult> Get([FromQuery] CityQueryParams queryParams)
    {
        try
        {
            var data = await _context.Cities.AsQueryable().Apply(queryParams)
                    .Include(x => x.State)
                        .ThenInclude(x => x.Country)
                    .AsNoTracking()
                    .ToListAsync();

            return StatusCode(
                200,
                new BaseResponseDto<ResponseCityDto>(
                    data.ConvertAll(
                            x => _mapper.Map<ResponseCityDto>(x)
                        ))
                );
        }
        catch (Exception e)
        {

            Console.WriteLine(e);
            return StatusCode(
                500, new BaseResponseDto<ResponseCityDto>(e.Message));
        }
    }


    [HttpGet("/v1/cities/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        try
        {


            var data = await _context.Cities.Where(x => x.Id == id)
                        .Include(x => x.State)
                        .ThenInclude(x => x.Country)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

            if (data == null)
            {
                return StatusCode(
                400, new BaseResponseDto<ResponseCityDto>(
                      "Não encontrado"
                    )
                );
            }

            return StatusCode(
                200,
                new BaseResponseDto<ResponseCityDto>(
                        CityMapper.FromModelToDto(data)
                    )
                );
        }
        catch (Exception e)
        {

            Console.WriteLine(e);
            return StatusCode(
                500, new BaseResponseDto<ResponseCityDto>(e.Message));
        }

    }



    [HttpPost("/v1/cities")]
    public async Task<IActionResult> Post([FromBody] CreateCityDto dto)
    {
        try
        {


            if (!ModelState.IsValid)
            {
                return StatusCode(400, new BaseResponseDto<ResponseCityDto>(ModelState.GetErrors()));
            }

            var data = CityMapper.FromDtoToModel(dto);
            var state = _context.States.Where(x => x.Id == dto.StateId).Include(x => x.Country).FirstOrDefault();

            if (state == null)
            {
                return StatusCode(400, new BaseResponseDto<ResponseCityDto>("Estado não encontrado"));
            }

            data.State = state;
            await _context.Cities.AddAsync(data);
            _context.SaveChanges();

            return StatusCode(
               200,
               new BaseResponseDto<ResponseCityDto>(
                       CityMapper.FromModelToDto(data)
                   )
               );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(
                500, new BaseResponseDto<ResponseCityDto>(e.Message));
        }
    }



    [HttpPatch("/v1/cities/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateCityDto dto)
    {
        try
        {
            if (!ModelState.IsValid) { }
            var element = await _context.Cities.Where(x => x.Id == id).Include(x => x.State).ThenInclude(x => x.Country).FirstOrDefaultAsync();

            if (element == null)
            {
                return StatusCode(
                400, new BaseResponseDto<ResponseCityDto>("Elemento não encontrado"));
            }
            var data = CityMapper.FromDtoToModel(dto);
            element.Name = data.Name;
            if (element.StateId != data.StateId)
            {
                var state = await _context.States.Where(x => x.Id == data.StateId).FirstOrDefaultAsync();
                if (state == null)
                {
                    return StatusCode(
                    400, "Estado não encontrado");
                }
                element.StateId = state.Id;
            }

            _context.Cities.Update(element);
            _context.SaveChanges();

            return StatusCode(
               200,
               new BaseResponseDto<ResponseCityDto>(
                       CityMapper.FromModelToDto(element)
                   )
               );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(
                500, new BaseResponseDto<ResponseCityDto>(e.Message));
        }

    }



    [HttpDelete("/v1/cities/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        try
        {
            var element = await _context.Cities.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (element == null)
            {
                return StatusCode(
                400, new BaseResponseDto<ResponseCityDto>("Elemento não encontrado"));
            }
            _context.Cities.Remove(element);
            _context.SaveChanges();

            return StatusCode(
               200,
               new BaseResponseDto<ResponseCityDto>()
               );
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(
                500, new BaseResponseDto<ResponseCityDto>(e.Message));
        }
    }

}
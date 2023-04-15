using AspNetCore.IQueryable.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.ContactInfo;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;
using ProjectsManagement.QueryParams;

namespace ProjectsManagement.Controllers;

[ApiController]
[Authorize]
public class ContactInfoController : ControllerBase
{

    ProjectsManagementContext Context;

    public ContactInfoController(ProjectsManagementContext context)
    {
        Context = context;
    }

    [AllowAnonymous]
    [HttpGet("/v1/contact-infos")]
    public async Task<IActionResult> Get([FromQuery] ContactInfoQueryParams queryParams)
    {
        var data = await Context.ContactInfos.AsQueryable().Apply(queryParams).AsNoTracking().ToListAsync();
        return StatusCode(
            200,
            new BaseResponseDto<ResponseContactInfoDto>(
                data.Select(
                        x => ContactInfoMapper.FromModelToDto(x)
                    ).ToList()
                )
            );
    }


    [HttpGet("/v1/contact-infos/{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var data = await Context.ContactInfos.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if (data == null)
        {
            return StatusCode(
            400
            );
        }
        return StatusCode(
            200,
            new BaseResponseDto<ResponseContactInfoDto>(ContactInfoMapper.FromModelToDto(data)

                )
            );

    }



    [HttpPost("/v1/contact-infos")]
    public async Task<IActionResult> Post(CreateContactInfoDto dto)
    {
        if (!ModelState.IsValid) { }

        var data = ContactInfoMapper.FromDtoToModel(dto);
        var type = Context.ContactTypes.Where(x => x.Id == dto.ContactTypeId).FirstOrDefault();

        if (type == null)
        {
            return StatusCode(
                        400
                        );
        }

        data.Type = type;
        await Context.ContactInfos.AddAsync(data);
        Context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseContactInfoDto>(
                   ContactInfoMapper.FromModelToDto(data)
               )
           );
    }



    [HttpPatch("/v1/contact-infos/{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateContactInfoDto dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(
                            400
                            );
        }

        var data = await Context.ContactInfos.Where(x => x.Id == id).FirstOrDefaultAsync();

        if (data == null)
        {
            return StatusCode(
                         400
                         );
        }

        var serializedData = ContactInfoMapper.FromDtoToModel(dto);

        if (serializedData.ContactTypeId != data.ContactTypeId)
        {

            var type = await Context.ContactTypes.Where(x => x.Id == serializedData.ContactTypeId).FirstOrDefaultAsync();

            if (type == null)
            {
                return StatusCode(
                            400
                            );
            }

            data.Type = type;
        }

        if (data.Value != serializedData.Value)
        {
            data.Value = serializedData.Value;
        }

        Context.ContactInfos.Update(data);
        Context.SaveChanges();

        return StatusCode(
           200,
           new BaseResponseDto<ResponseContactInfoDto>(
                   ContactInfoMapper.FromModelToDto(data)
               )
           );
    }



    [HttpDelete("/v1/contact-infos/{id:int}")]
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
           new BaseResponseDto<ResponseContactInfoDto>()
           );
    }

}
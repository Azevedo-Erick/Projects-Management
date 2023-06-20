using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using AutoMapper;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Permission;
using ProjectsManagement.Mappers;

namespace ProjectsManagement.Controllers
{
    [ApiController]
    [Authorize]
    public class PermissionController : ControllerBase
    {
        private readonly ProjectsManagementContext _context;

        private readonly IMapper _mapper;
        public PermissionController(ProjectsManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [AllowAnonymous]
        [HttpGet("/v1/permissions")]
        public async Task<IActionResult> Get()
        {
            List<Models.Permission> data = await _context.Permissions.ToListAsync();
            return StatusCode(200, new BaseResponseDto<List<ResponsePermissionDto>>(data.ConvertAll(PermissionMapper.FromModelToDto)));
        }

        [HttpGet("/v1/permissions/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Models.Permission? data = await _context.Permissions.Where(x => x.Id == id).FirstOrDefaultAsync();
            return data == null
                ? StatusCode(400)
                : StatusCode(200, new BaseResponseDto<ResponsePermissionDto>(PermissionMapper.FromModelToDto(data)));
        }

        [HttpPost("/v1/permissions")]
        public async Task<IActionResult> Post(CreatePermissionDto dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new BaseResponseDto<ResponsePermissionDto>());
            }
            Models.Permission data = PermissionMapper.FromDtoToModel(dto);

            _ = await _context.Permissions.AddAsync(data);
            _ = _context.SaveChanges();
            return StatusCode(201, new BaseResponseDto<ResponsePermissionDto>(PermissionMapper.FromModelToDto(data)));
        }

        [HttpPatch("/v1/permissions/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreatePermissionDto dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new BaseResponseDto<ResponsePermissionDto>());
            }
            Models.Permission data = PermissionMapper.FromDtoToModel(dto);

            Models.Permission? model = await _context.Permissions.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (model == null)
            {
                return StatusCode(404, new BaseResponseDto<ResponsePermissionDto>());
            }

            if (model.Name != data.Name)
            {
                model.Name = data.Name;
            }

            _ = _context.Permissions.Update(data);
            _ = _context.SaveChanges();
            return StatusCode(201, new BaseResponseDto<ResponsePermissionDto>(PermissionMapper.FromModelToDto(data)));
        }

        [HttpDelete("/v1/permissions/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Models.Permission? data = await _context.Permissions.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (data == null)
            {
                return StatusCode(404, new BaseResponseDto<ResponsePermissionDto>());
            }
            _ = _context.Permissions.Remove(data);
            return StatusCode(200, new BaseResponseDto<ResponsePermissionDto>());
        }
    }
}
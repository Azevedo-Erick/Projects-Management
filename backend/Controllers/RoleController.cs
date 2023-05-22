using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsManagement.Data;
using ProjectsManagement.Dtos;
using ProjectsManagement.Dtos.Role;
using ProjectsManagement.Mappers;
using ProjectsManagement.Models;

namespace ProjectsManagement.Controllers
{
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private readonly ProjectsManagementContext _context;

        public RoleController(ProjectsManagementContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpGet("/v1/roles")]
        public async Task<IActionResult> Get()
        {
            List<Role> data = await _context.Roles.ToListAsync();
            return StatusCode(200, new BaseResponseDto<ResponseRoleDto>(data.ConvertAll(RoleMapper.FromModelToDto)));
        }

        [HttpGet("/v1/roles/{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            Role? data = await _context.Roles.Where(x => x.Id == id).Include(x => x.Permissions).FirstOrDefaultAsync();
            return data == null
                ? StatusCode(400, new BaseResponseDto<ResponseRoleDto>())
                : (IActionResult)StatusCode(200, new BaseResponseDto<ResponseRoleDto>(RoleMapper.FromModelToDto(data)));
        }

        [HttpPost("/v1/roles")]
        public async Task<IActionResult> Post(CreateRoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new BaseResponseDto<ResponseRoleDto>());
            }

            Role data = RoleMapper.FromDtoToModel(dto);

            List<Permission> permissions = await _context.Permissions.Where(x => dto.Permissions.Contains(x.Id)).ToListAsync();

            if (permissions.Count != dto.Permissions.Count)
            {
                return StatusCode(400, new BaseResponseDto<ResponseRoleDto>());
            }
            _ = await _context.Roles.AddAsync(data);
            foreach (Permission? permission in permissions)
            {
                _ = _context.RolePermissions.Add(new RolePermission
                {
                    RoleId = data.Id,
                    PermissionId = permission.Id
                });
            }
            return StatusCode(200, new BaseResponseDto<ResponseRoleDto>(RoleMapper.FromModelToDto(data)));
        }

        [HttpPatch("/v1/roles/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] CreateRoleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new BaseResponseDto<ResponseRoleDto>());
            }
            Role? model = await _context.Roles.Where(x => x.Id == id).Include(x => x.Permissions).FirstOrDefaultAsync();
            if (model == null)
            {
                return StatusCode(400, new BaseResponseDto<ResponseRoleDto>());
            }
            Role data = RoleMapper.FromDtoToModel(dto);
            if (model.Name != data.Name)
            {
            }
            List<int> modelPermissions = model.Permissions!.ConvertAll(x => x.PermissionId);
            if (modelPermissions.Count != dto.Permissions.Count)
            {
                model.Permissions.Clear();
                foreach (int permission in dto.Permissions)
                {
                    model.Permissions.Add(new RolePermission
                    {
                        PermissionId = permission,
                        RoleId = id
                    });
                }
            }
            _ = _context.Roles.Update(model);
            _ = _context.SaveChanges();
            return StatusCode(200, new BaseResponseDto<ResponseRoleDto>(RoleMapper.FromModelToDto(model)));
        }

        [HttpDelete("/v1/roles/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            Role? data = await _context.Roles.Where(x => x.Id == id).Include(x => x.Permissions).FirstOrDefaultAsync();
            if (data == null)
            {
                return StatusCode(404, new BaseResponseDto<ResponseRoleDto>());
            }
            if (data.Permissions != null)
            {
                _context.RolePermissions.RemoveRange(
                    data.Permissions
                );
            }
            _ = _context.Roles.Remove(data);
            _ = _context.SaveChanges();
            return StatusCode(200, new BaseResponseDto<ResponseRoleDto>());
        }
    }
}
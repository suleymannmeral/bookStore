
using BooklyBookStoreApp.Application.DTOs.RoleDtos;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Presentation.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace BooklyBookStoreApp.Presentation.Controllers;

public sealed class RolesController : BaseApiController
{
    public RolesController(IServiceManager manager) : base(manager)
    {

    }
    [HttpPost("create-role")]

    public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleDto request)
    {
        
        await _manager.RoleService.CreateRoleAsync(request);
        return Ok(new
        {
            message = "Role created successfully"
        });
    }
    [HttpPost("create-UserRole")]

    public async Task<IActionResult> CreateUserRoleAsync([FromBody] CreateUserRoleDto request)
    {

        await _manager.RoleService.CreateUserRole(request);
        return Ok(new
        {
            message = "Role created successfully"
        });
    }

}

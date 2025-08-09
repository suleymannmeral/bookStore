using BooklyBookStoreApp.Application.DTOs.RoleDtos;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Domain.Entitites;
using BooklyBookStoreApp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BooklyBookStoreApp.Persistence.Services;

public sealed class RoleService : IRoleService
{
    private readonly RoleManager<Role> _roleManagaer;
    private readonly IRepositoryManager _repositoryManager;

    public RoleService(RoleManager<Role> roleManagaer, IRepositoryManager repositoryManager)
    {
        _roleManagaer = roleManagaer;
        _repositoryManager = repositoryManager;
    }

    public async Task CreateRoleAsync(CreateRoleDto request)
    {
        Role role = new()
        {
            Name = request.Name,
           
        };

        await _roleManagaer.CreateAsync(role);
    }

    public async Task CreateUserRole(CreateUserRoleDto request)
    {
       UserRole userRole = new()
        {
            RoleId = request.RoleId,
            UserId = request.UserId
        };
        _repositoryManager.UserRole.Create(userRole);
        await _repositoryManager.Save();

    }

    public Task<List<string>> GetRolesByUserIdAsync(string userId)
    {
        return  _repositoryManager.UserRole.FindByCondition(ur => ur.UserId == userId,false)
       .Include(ur => ur.Role)
       .Select(ur => ur.Role.Name)
       .ToListAsync();
    }
}

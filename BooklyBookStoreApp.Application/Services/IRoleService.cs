using BooklyBookStoreApp.Application.DTOs.RoleDtos;

namespace BooklyBookStoreApp.Application.Services
{
    public interface IRoleService
    {
        Task CreateRoleAsync(CreateRoleDto request);
        Task CreateUserRole(CreateUserRoleDto request);
        Task<List<string>> GetRolesByUserIdAsync(string userId);
    }
}

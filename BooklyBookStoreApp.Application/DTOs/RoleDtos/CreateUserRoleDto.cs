

namespace BooklyBookStoreApp.Application.DTOs.RoleDtos;

public record CreateUserRoleDto
{
    public string RoleId { get; set; }
    public string UserId { get; set; }
}

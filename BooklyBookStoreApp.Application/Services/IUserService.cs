

using BooklyBookStoreApp.Application.DTOs.UserDtos;

namespace BooklyBookStoreApp.Application.Services;

public interface IUserService
{
    Task RegisterAsync(RegisterUserDto registerUserDto);
    Task<LoginResponseDto> LoginAsync(LoginUserDto registerUserDto);


}

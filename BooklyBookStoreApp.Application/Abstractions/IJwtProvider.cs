using BooklyBookStoreApp.Application.DTOs.UserDtos;
using BooklyBookStoreApp.Domain.Entitites;


namespace BooklyBookStoreApp.Application.Abstractions;

public  interface IJwtProvider
{
    Task<LoginResponseDto> CreateTokenAsync(User user);
}



namespace BooklyBookStoreApp.Application.DTOs.UserDtos;

public record LoginResponseDto(
 string Token,
 string RefreshToken,
 DateTime RefreshTokenExpires,
 string UserId

);

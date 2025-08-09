

using BooklyBookStoreApp.Application.Abstractions;
using BooklyBookStoreApp.Application.DTOs.UserDtos;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Domain.Entitites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserManager<User> _user;
    private readonly IRoleService _roleService;

    public JwtProvider(IOptions<JwtOptions> jwtOptions, UserManager<User> user, IRoleService roleService)
    {
        _jwtOptions = jwtOptions.Value;
        _user = user;
        _roleService = roleService;
    }
    public async Task<LoginResponseDto> CreateTokenAsync(User user)
    {
        // 1️⃣ Kullanıcının rollerini veritabanından çek
        var roles = await _roleService.GetRolesByUserIdAsync(user.Id);

        // 2️⃣ Temel claim'leri oluştur
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Email, user.Email),
        new Claim(JwtRegisteredClaimNames.Name, user.UserName),
        new Claim("NameLastName", user.NameSurname)
    };

        // 3️⃣ Roller claim olarak ekleniyor
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        // 4️⃣ Token süresini belirle
        DateTime expires = DateTime.Now.AddHours(1);

        // 5️⃣ JWT token'ı oluştur
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
                SecurityAlgorithms.HmacSha256
            )
        );

        // 6️⃣ Token'ı string'e çevir
        string token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        // 7️⃣ Refresh Token oluştur ve kaydet
        string refreshToken = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
        user.RefreshToken = refreshToken;
        user.RefreshTokenExpires = expires.AddMinutes(15);
        await _user.UpdateAsync(user);

        // 8️⃣ Cevap dön
        return new LoginResponseDto(token, refreshToken, user.RefreshTokenExpires, user.Id);
    }


}

using AutoMapper;
using BooklyBookStoreApp.Application.Abstractions;
using BooklyBookStoreApp.Application.DTOs.UserDtos;
using BooklyBookStoreApp.Application.Services;
using BooklyBookStoreApp.Domain.Entitites;
using BooklyBookStoreApp.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BooklyBookStoreApp.Persistence.Services;

public class UserService : IUserService
{
    private readonly UserManager<User>_userManager;
    private readonly IMapper _mapper;
    private readonly IJwtProvider _jwtProvider;
    private readonly IBasketService _basketService;

    public UserService(UserManager<User> userManager, IMapper mapper, IJwtProvider jwtProvider, IBasketService basketService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _jwtProvider = jwtProvider;
        _basketService = basketService;
    }

    public async Task<LoginResponseDto> LoginAsync(LoginUserDto request)
    {
        User user = await _userManager.Users.Where(p =>
        p.UserName == request.UserName
        ).FirstOrDefaultAsync();

        if (user == null)
        {
            throw new Exception("user not found");
        }

      var result =  await _userManager.CheckPasswordAsync(user,request.Password);
        if(result)
        {
            LoginResponseDto response = await _jwtProvider.CreateTokenAsync(user);
            return response;

        }
        throw new Exception("Invalid password");
     
    }

    public async Task RegisterAsync(RegisterUserDto request)
    {
        try
        {
            User user = _mapper.Map<User>(request);
            IdentityResult result = await _userManager.CreateAsync(user, request.Password);
            await _basketService.CreateUserBasket(user.Id);
            


            if (!result.Succeeded)
            {
                var errorMessages = result.Errors.Select(e => e.Description);
                throw new Exception(string.Join(" | ", errorMessages));
            }
        }
        catch (Exception ex)
        {
            // InnerException varsa onu da yakala
            throw new Exception(ex.InnerException?.Message ?? ex.Message);
        }
    }

}

using BooklyBookStoreApp.Application.DTOs.UserDtos;
using FluentValidation;


namespace BooklyBookStoreApp.Application.Validator.UserValidators;

public class LoginUserDtoValidators : AbstractValidator<LoginUserDto>
{
    public LoginUserDtoValidators()
    {
        RuleFor(p => p.UserName)
            .NotEmpty().WithMessage("UserName is required");

        RuleFor(p => p.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long");
    }
}

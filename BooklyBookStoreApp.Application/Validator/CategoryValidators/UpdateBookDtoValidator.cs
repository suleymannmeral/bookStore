

using BooklyBookStoreApp.Application.DTOs.CategoryDtos;
using FluentValidation;

namespace BooklyBookStoreApp.Application.Validator.CategoryValidators;

public class UpdateBookDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateBookDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .NotNull().WithMessage("Name cannot be null.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");
    }
}

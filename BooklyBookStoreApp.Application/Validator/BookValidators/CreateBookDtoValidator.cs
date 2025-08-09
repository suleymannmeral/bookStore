using BooklyBookStoreApp.Application.DTOs.BookDtos;
using FluentValidation;


namespace BooklyBookStoreApp.Application.Validator.BookValidators;

public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
{
    public CreateBookDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required.");
        RuleFor(x => x.Title).NotNull().WithMessage("Title is required.");
        RuleFor(x => x.Price).GreaterThan(10).WithMessage("Price must be greater than 10.");
    }
}

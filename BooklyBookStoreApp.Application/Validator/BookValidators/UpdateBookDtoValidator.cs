using BooklyBookStoreApp.Application.DTOs.BookDtos;
using FluentValidation;


namespace BooklyBookStoreApp.Application.Validator.BookValidators;

public sealed class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
{
    public UpdateBookDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .NotNull().WithMessage("Title cannot be null.");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(x => x.Title)
    .NotEmpty().WithMessage("Title is required.")
    .NotNull().WithMessage("Title cannot be null.");
        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

    }
}

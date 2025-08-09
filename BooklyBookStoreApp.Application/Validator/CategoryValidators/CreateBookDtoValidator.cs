using BooklyBookStoreApp.Application.DTOs.CategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Application.Validator.CategoryValidators
{
    public sealed class CreateBookDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateBookDtoValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is required.")
                .NotNull().WithMessage("Name cannot be null.");
        
        }
    }
}

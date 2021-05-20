using FluentValidation;
using Lab1.DTOs.CategoryDTOs;

namespace Lab1.Validators
{
    public class CategoryValidator : AbstractValidator<CategoryRequestDto>
    {
        public CategoryValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Length(5, 100);
            RuleFor(e => e.Description).MaximumLength(250);
        }
    }
}
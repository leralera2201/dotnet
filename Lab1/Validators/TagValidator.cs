using FluentValidation;
using Lab1.DTOs.TagDTOs;

namespace Lab1.Validators
{
    public class TagValidator : AbstractValidator<TagRequestDto>
    {
        public TagValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Length(5, 100);
            RuleFor(e => e.Description).MaximumLength(250);
        }
    }
}
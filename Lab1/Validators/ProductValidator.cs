using FluentValidation;
using Lab1.DTOs.ProductDTOs;

namespace Lab1.Validators
{
    public class ProductValidator : AbstractValidator<ProductRequestDto>
    {
        public ProductValidator()
        {
            RuleFor(e => e.Name).NotEmpty().Length(5, 100);
            RuleFor(e => e.Code).NotEmpty().Length(1, 20);
            RuleFor(e => e.Description).MaximumLength(250);
            RuleFor(e => e.Price).NotEmpty().GreaterThan(0); ;
            RuleFor(e => e.CategoryId).NotEmpty();
        }
    }
}
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Application.ViewModels.Products;

namespace Ticaret.Application.Validators.Products
{
    public class ProductCreateValidator : AbstractValidator<ProductCreateViewModel>
    {
        public ProductCreateValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is required")           
                .MaximumLength(150)
                .MinimumLength(3)
                .WithMessage("Name between 3 and 150 characters");

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Price is required")
                .Must(k => k > 0)
                .WithMessage("Price must be greater than 0");
            
            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Stock is required")
                .Must(k => k > 0)
                .WithMessage("Stock must be greater than 0");
        }
    }
}

using FluentValidation;
using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Validation
{
    public class ProductValidation:AbstractValidator<Product>
    {
        public ProductValidation() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adını boş geçmeyiniz");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Kategori açıklaması boş geçmeyiniz");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("En az 1 olmalı");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Kategori açıklaması boş geçmeyiniz");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("En az 1 olmalı");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 karekter girilmeli");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("En fazla 20 karekter girilmeli");
        }
    }
}

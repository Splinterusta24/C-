using FluentValidation;
using Project.Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Business.Validation
{
    public class CategoryValidation:AbstractValidator<Category>
    {

        public CategoryValidation()
        {
            
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori Adını boş geçmeyiniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Kategori açıklaması boş geçmeyiniz");
            RuleFor(x => x.Description).MinimumLength(3).WithMessage("En az 3 karekter girilmeli");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En az 3 karekter girilmeli");
            RuleFor(x => x.Description).MaximumLength(30).WithMessage("En fazla 20 karekter girilmeli");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("En fazla 20 karekter girilmeli");

        }
    }
}

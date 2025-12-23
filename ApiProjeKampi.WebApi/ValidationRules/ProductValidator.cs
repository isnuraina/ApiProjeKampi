using ApiProjeKampi.WebApi.Entities;
using FluentValidation;

namespace ApiProjeKampi.WebApi.ValidationRules
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Ürün adını boş geçmeyin!");
            RuleFor(p => p.ProductName).MinimumLength(2).WithMessage("En az 2 karakter veri girişi  yapın!");
            RuleFor(p => p.ProductName).MaximumLength(50).WithMessage("En fazla 50 karakter veri girişi yapın!");
            RuleFor(p=>p.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez!").GreaterThan(0).WithMessage("Ürün fiyatı negatif olamaz!")
                .LessThan(1000).WithMessage("Ürün fiyatı bu kadar yüksek olamaz,girdiğiniz değeri kontrol edin!");
            RuleFor(p=>p.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez!");
        }
    }
}

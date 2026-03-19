using FluentValidation;
using Products_WebApi.DTO.Requests;

namespace Products_WebApi.ProductValidators;

public class UpdateProductRequestValidator : AbstractValidator<UpdateProductRequest>
{
    int maxLengthString = 30;
    public UpdateProductRequestValidator()
    {
        RuleFor(p => p.Name).MaximumLength(maxLengthString).NotEmpty();
        RuleFor(p => p.Category).MaximumLength(maxLengthString).NotEmpty();
        RuleFor(p => p.Price).Must(price => price > 0).NotEmpty();
    }
}
using FluentValidation;
using Products_WebApi.DTO.Requests;

namespace Products_WebApi.ProductValidators;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    int maxLengthString = 30;
    public CreateProductRequestValidator()
    {
        RuleFor(p => p.Name).MaximumLength(maxLengthString).NotEmpty();
        RuleFor(p => p.Category).MaximumLength(maxLengthString).NotEmpty();
        RuleFor(p => p.Price).Must(price => price > 0).NotEmpty();
    }
}
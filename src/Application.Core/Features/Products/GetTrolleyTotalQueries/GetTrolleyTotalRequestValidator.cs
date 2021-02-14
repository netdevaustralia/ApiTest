namespace Application.Features.Products.GetTrolleyTotalQueries
{
    using FluentValidation;

    public class GetTrolleyTotalRequestValidator : AbstractValidator<GetTrolleyTotalRequest>
    {
        public GetTrolleyTotalRequestValidator()
        {
            RuleFor(x => x.Products).NotNull();
            RuleFor(x => x.Specials).NotNull();
            RuleFor(x => x.Quantities).NotNull();
        }
    }
}
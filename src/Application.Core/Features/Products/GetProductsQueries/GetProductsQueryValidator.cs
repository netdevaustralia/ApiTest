namespace Application.Features.Products.Queries
{
    using FluentValidation;

    public class GetProductsQueryValidator : AbstractValidator<GetProductsRequest>
    {
        //TODO if sort option is not available or null then throw validation
    }
}
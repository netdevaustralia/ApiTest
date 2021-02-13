namespace Application.Features.Products.Queries
{
    using Application.Common.Enums;
    using MediatR;

    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public SortOption SortOption { get; set; }
    }
}
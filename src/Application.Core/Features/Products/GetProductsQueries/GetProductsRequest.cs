namespace Application.Features.Products.GetProductsQueries
{
    using Common.Enums;
    using MediatR;

    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
        public SortOption SortOption { get; set; }
    }
}
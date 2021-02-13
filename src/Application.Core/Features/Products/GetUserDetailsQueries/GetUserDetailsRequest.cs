namespace Application.Users.Queries
{
    using Application.Core.Models;
    using MediatR;

    public class GetUserDetailsRequest : IRequest<GetUserDetailsResponse>
    {
    }
}
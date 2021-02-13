namespace Application.Users.Queries
{
    using Application.Core.Config;
    using Application.Core.Models;
    using MediatR;
    using Microsoft.Extensions.Options;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsRequest, GetUserDetailsResponse>
    {
        private readonly ProductServiceConfig _config;

        public GetUserDetailsQueryHandler(IOptions<ProductServiceConfig> config)
        {
            _config = config.Value;
        }

        public async Task<GetUserDetailsResponse> Handle(GetUserDetailsRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new GetUserDetailsResponse
            {
                Name = _config.UserName,
                Token = _config.Token
            });
        }
    }
}
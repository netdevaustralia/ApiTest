using Application.Core.Config;
using Application.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsRequest, GetUserDetailsResponse>
    {
        private readonly UserConfig _userConfig;

        public GetUserDetailsQueryHandler(IOptions<UserConfig> userConfig)
        {
            _userConfig = userConfig.Value;
        }

        public async Task<GetUserDetailsResponse> Handle(GetUserDetailsRequest request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new GetUserDetailsResponse
            {
                Name = _userConfig.Name,
                Token = _userConfig.Token
            });
        }
    }
}

namespace Application.Common.Behaviours
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Microsoft.Extensions.Logging;

    public class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger _logger;
        
        public LoggingBehaviour(ILogger logger)
        {
            _logger = logger;
        }


        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            var name = typeof(TRequest).Name;
            _logger.LogInformation("Api Request start: {Name} {@Request}", name, request);
            var response = await next();
            _logger.LogInformation("Api Request end : {Name} {@Request}", name, request);
            return response;
        }
    }
}
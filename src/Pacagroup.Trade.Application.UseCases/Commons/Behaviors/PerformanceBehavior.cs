using System.Diagnostics;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Pacagroup.Trade.Application.UseCases.Commons.Behaviors
{
    public class PerformanceBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ILogger<TRequest> _logger;
        private readonly Stopwatch _timer;

        public PerformanceBehavior(ILogger<TRequest> logger)
        {
            _logger = logger;
            _timer = new Stopwatch();
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;
            if (elapsedMilliseconds > 10) // Log if the request takes longer than 500ms
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogWarning("Long running request: {RequestName} took {ElapsedMilliseconds} ms {request}",
                                     requestName,
                                     elapsedMilliseconds,
                                     JsonSerializer.Serialize(request));
            }

            return response;
        }
    }
}
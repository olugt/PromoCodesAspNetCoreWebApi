using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Pipelines
{
    /// <summary>
    /// MediatR pipeline behaviour implementation for logging message requests and responses.
    /// </summary>
    /// <typeparam name="TRequest">The request.</typeparam>
    /// <typeparam name="TResponse">The response.</typeparam>
    class LoggingPipeline<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggingPipeline<TRequest, TResponse>> _logger;

        public LoggingPipeline(ILogger<LoggingPipeline<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var guid = Guid.NewGuid();

            var requestName = $"{request.GetType().Name}_{guid}";
            _logger.LogInformation($"Handling request: {requestName}");

            var responseName = $"{typeof(TResponse).Name}_{guid}";
            TResponse response;

            try
            {
                response = await next();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"\nRequest: {requestName} \nResponse: {responseName} \nException: \n{JsonSerializer.Serialize(ex)}", null);

                throw ex;
            }
            finally
            {
                _logger.LogInformation($"Handled request: {requestName}");
                _logger.LogInformation($"Handled response: {responseName}");
            }

            return response;
        }
    }
}

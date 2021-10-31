using System.Text.Json;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Interceptors
{
    public sealed class LoggingInterceptor : Interceptor
    {
        private readonly ILogger<LoggingInterceptor> _Logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            this._Logger = logger;
        }

        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
            TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var requestJson = JsonSerializer.Serialize(request);
            this._Logger.LogInformation(requestJson);

            var response = base.UnaryServerHandler(request, context, continuation);

            if (null == response.Exception)
            {
                var responseJson = JsonSerializer.Serialize(response);
                this._Logger.LogInformation(responseJson);
            }

            return response;
        }
    }
}

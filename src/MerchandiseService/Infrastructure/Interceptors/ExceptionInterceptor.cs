using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace MerchandiseService.Infrastructure.Interceptors
{
    public sealed class ExceptionInterceptor : Interceptor
    {
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
           TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation(request, context).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is not RpcException)
            {
                throw new RpcException(
                    new Status(StatusCode.Cancelled, ex.Message)
                );
            }
        }
    }
}

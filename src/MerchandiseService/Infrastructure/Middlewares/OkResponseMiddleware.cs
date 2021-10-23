using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public sealed class OkResponseMiddleware
    {
        // ReSharper disable once UnusedParameter.Local
        public OkResponseMiddleware(RequestDelegate next)
        {
        }

        #pragma warning disable 1998
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
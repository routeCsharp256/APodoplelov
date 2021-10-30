using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public sealed class OkResponseMiddleware
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Redundancy", "RCS1163:Unused parameter.", Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public OkResponseMiddleware(RequestDelegate next)
        {
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status200OK;
            _ = context.Response.WriteAsync("all systems green").ConfigureAwait(false);
        }
    }
}

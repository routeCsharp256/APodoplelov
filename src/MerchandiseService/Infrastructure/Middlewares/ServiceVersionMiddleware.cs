using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public sealed class ServiceVersionMiddleware
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Redundancy", "RCS1163:Unused parameter.", Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>")]
        public ServiceVersionMiddleware(RequestDelegate next)
        {
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task InvokeAsync(HttpContext context)
        {
            var service = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            var version = service.Version?.ToString() ?? "version not found";
            var serviceName = service.Name;
            var responseJson = JsonSerializer.Serialize(new
            {
                version,
                serviceName,
            }
            );

            _ = context.Response.WriteAsync(responseJson).ConfigureAwait(false);
        }
    }
}

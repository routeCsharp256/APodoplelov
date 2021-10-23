using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public sealed class ServiceVersionMiddleware
    {
        // ReSharper disable once UnusedParameter.Local
        public ServiceVersionMiddleware(RequestDelegate next)
        {
        }

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

            await context.Response.WriteAsync(responseJson);
        }
    }
}
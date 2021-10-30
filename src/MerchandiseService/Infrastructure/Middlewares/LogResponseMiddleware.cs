using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public sealed class LogResponseMiddleware
    {
        private readonly RequestDelegate NextDelegate;
        private readonly ILogger<LogResponseMiddleware> Logger;

        public LogResponseMiddleware(RequestDelegate next, ILogger<LogResponseMiddleware> logger)
        {
            this.NextDelegate = next;
            this.Logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await this.NextDelegate(context).ConfigureAwait(false);

            if (context.Response.HasStarted)
            {
                this.LogResponse(context);
            }
        }

        private const string LogTemplate = "{result}";

        private void LogResponse(HttpContext context)
        {
            var sb = new StringBuilder();

            sb.Append("Route: ").Append(context.GetEndpoint()?.DisplayName).Append(Environment.NewLine).Append(Environment.NewLine);

            foreach ((var key, StringValues value) in context.Response.Headers)
            {
                sb.Append(key).Append(": ").Append(value).Append(Environment.NewLine);
            }

            this.Logger.LogInformation(LogTemplate, sb.ToString().Trim());
        }
    }
}

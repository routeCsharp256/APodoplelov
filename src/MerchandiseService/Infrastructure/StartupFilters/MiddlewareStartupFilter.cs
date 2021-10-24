using System;
using MerchandiseService.Infrastructure.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MerchandiseService.Infrastructure.StartupFilters
{
    public sealed class MiddlewareStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.Map("/version", builder => builder.UseMiddleware<ServiceVersionMiddleware>());

                app.Map("/ready", builder => builder.UseMiddleware<OkResponseMiddleware>());
                app.Map("/live", builder => builder.UseMiddleware<OkResponseMiddleware>());

                // TODO exclude grpc requests
                app.UseMiddleware<LogRequestMiddleware>();
                app.UseMiddleware<LogResponseMiddleware>();

                next(app);
            };
        }
    }
}

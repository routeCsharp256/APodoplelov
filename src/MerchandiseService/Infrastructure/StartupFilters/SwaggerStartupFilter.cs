using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace MerchandiseService.Infrastructure.StartupFilters
{
    public sealed class SwaggerStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UseSwagger();
                app.UseSwaggerUI(
                    config =>
                    {
                        config.SwaggerEndpoint("/swagger/v1/swagger.json", "Merchandise API");
                        config.RoutePrefix = string.Empty;
                    }
                );

                next(app);
            };
        }
    }
}

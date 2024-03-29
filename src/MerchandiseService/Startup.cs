﻿using MerchandiseService.GrpcServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MerchandiseService
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructureServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
                {
                    endpoints.MapGrpcService<MerchandiseGrpcService>();

                    endpoints.MapGrpcReflectionService();

                    endpoints.MapControllers();

                    endpoints.Map("{any}", async context =>
                        await context.Response.WriteAsync("ok!").ConfigureAwait(false));
                }
            );
        }
    }
}

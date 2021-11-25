using MediatR;
using MerchandiseService.Infrastructure.Handlers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CheckDeliveryCommandHandler).Assembly);
            services.AddMediatR(typeof(CreateDeliveryCommandHandler).Assembly);
            services.AddMediatR(typeof(NewStockCommandHandler).Assembly);

            return services;
        }

        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            return services;
        }
    }
}

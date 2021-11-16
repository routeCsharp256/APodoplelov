using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.DeliveryAggregate;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Infrastructure.Commands;

namespace MerchandiseService.Infrastructure.Handlers
{
    public sealed class CheckDeliveryCommandHandler : IRequestHandler<CheckDeliveryCommand, bool>
    {
        private readonly IDeliveryRepository DeliveryRepository;

        public CheckDeliveryCommandHandler(IDeliveryRepository deliveryRepository)
        {
            this.DeliveryRepository = deliveryRepository;
        }

        public async Task<bool> Handle(CheckDeliveryCommand request, CancellationToken cancellationToken)
        {
            var employee = new EmployeeEntity(request.EmployeeId);
            var merchPack = new MerchPackEntity(request.MerchPackId);
            var foundDelivery = await DeliveryRepository
                .FindByEmployeeAndMerchPackAsync(employee, merchPack, cancellationToken).ConfigureAwait(false);

            return foundDelivery is not null;
        }
    }
}

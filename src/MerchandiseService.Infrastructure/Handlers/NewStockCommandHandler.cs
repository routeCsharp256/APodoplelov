using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.DeliveryAggregate;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Infrastructure.Commands;

namespace MerchandiseService.Infrastructure.Handlers
{
    public sealed class NewStockCommandHandler : IRequestHandler<NewStockCommand, bool>
    {
        private readonly IDeliveryRepository DeliveryRepository;

        public NewStockCommandHandler(IDeliveryRepository deliveryRepository)
        {
            this.DeliveryRepository = deliveryRepository;
        }

        public async Task<bool> Handle(NewStockCommand request, CancellationToken cancellationToken)
        {
            var item = new ItemEntity(request.ItemId);

            var delayedPacks = await this.DeliveryRepository
                .FindDelayedPacksByItem(item, request.Quantity, cancellationToken).ConfigureAwait(false);
            if (0 == delayedPacks.Length) {
                return false;
            }

            var available = request.Quantity;
            foreach (var delayedPack in delayedPacks)
            {
                await this.DeliveryRepository
                    .UpdateDelayedPackItemQuantity(delayedPack, item, ref available, cancellationToken).ConfigureAwait(false);
                if (available < 1) {
                    break;
                }
            }

            return true;
        }
    }
}

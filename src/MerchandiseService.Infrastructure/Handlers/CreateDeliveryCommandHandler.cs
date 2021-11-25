using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregationModels.DeliveryAggregate;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Infrastructure.Commands;

namespace MerchandiseService.Infrastructure.Handlers
{
    public sealed class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, int>
    {
        private readonly IDeliveryRepository DeliveryRepository;

        public CreateDeliveryCommandHandler(IDeliveryRepository deliveryRepository)
        {
            this.DeliveryRepository = deliveryRepository;
        }

        public async Task<int> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            var employee = new EmployeeEntity(request.EmployeeId);
            var merchPack = new MerchPackEntity(request.MerchPackId);
            var foundDelivery = await DeliveryRepository
                .FindByEmployeeAndMerchPackAsync(employee, merchPack, cancellationToken).ConfigureAwait(false);
            if (foundDelivery is not null)
            {
                throw new Exception($"Delivery for employee id {request.EmployeeId} with merch pack id {request.MerchPackId} already exist.");
            }

            var newDelivery = new DeliveryEntity(
                DateTime.UtcNow,
                new EmployeeEntity(request.EmployeeId),
                new MerchPackEntity(request.MerchPackId),
                DeliveryStatusEnumeration.InWork);

            var createResult = await this.DeliveryRepository.CreateAsync(newDelivery, cancellationToken).ConfigureAwait(false);
            if (createResult.IsTransient())
            {
                throw new Exception($"Error creating new delivery for employee id {request.EmployeeId} with merch pack id {request.MerchPackId}.");
            }

            await this.DeliveryRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken).ConfigureAwait(false);

            return newDelivery.Id;
        }
    }
}

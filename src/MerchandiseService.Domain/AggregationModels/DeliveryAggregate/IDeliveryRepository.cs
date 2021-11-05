using System.Threading.Tasks;
using System.Threading;
using MerchandiseService.Domain.Contracts;
using MerchandiseService.Domain.AggregationModels.Entities;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;

namespace MerchandiseService.Domain.AggregationModels.DeliveryAggregate
{
    public interface IDeliveryRepository : IRepository<DeliveryEntity>
    {
        Task<DeliveryEntity> FindByEmployeeAndMerchPackAsync(
            EmployeeEntity employee,
            MerchPackEntity merchPack,
            CancellationToken cancellationToken = default
        );
    }
}

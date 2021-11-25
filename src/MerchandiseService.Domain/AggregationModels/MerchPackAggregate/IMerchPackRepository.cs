using System.Threading.Tasks;
using System.Threading;
using MerchandiseService.Domain.Contracts;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public interface IMerchPackRepository : IRepository<MerchPackEntity>
    {
        Task<MerchPackEntity> FindByIdAsync(int id, CancellationToken cancellationToken = default);
    }
}

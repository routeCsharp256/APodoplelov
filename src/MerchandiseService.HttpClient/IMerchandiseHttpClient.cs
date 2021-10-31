using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.RestModels;

namespace MerchandiseService.HttpClients
{
    public interface IMerchandiseHttpClient
    {
        Task<MerchandiseDemandResponse> SendDemand(MerchandiseDemandRequest request, CancellationToken token);

        Task<MerchandiseInfoResponse> GetInfo(MerchandiseInfoRequest request, CancellationToken token);
    }
}

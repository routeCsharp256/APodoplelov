using System.Threading.Tasks;
using Grpc.Core;
using MerchandiseService.Grpc;

namespace MerchandiseService.GrpcServices
{
    public sealed class MerchandiseGrpcService : MerchandiseServiceGrpc.MerchandiseServiceGrpcBase
    {
        public override Task<MerchandiseDemandResponse> SendDemand(MerchandiseDemandRequest request, ServerCallContext context)
        {
            throw new RpcException(
                new Status(StatusCode.Cancelled, "not implemented")
            );
        }

        public override Task<MerchandiseInfoResponse> GetInfo(MerchandiseInfoRequest request, ServerCallContext context)
        {
            throw new RpcException(
                new Status(StatusCode.Cancelled, "not implemented")
            );
        }
    }
}

using MediatR;

namespace MerchandiseService.Infrastructure.Commands
{
    public sealed class CheckDeliveryCommand : IRequest<bool>
    {
        public int EmployeeId { get; init; }
        public int MerchPackId { get; init; }
    }
}

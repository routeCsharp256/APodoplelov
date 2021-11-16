using MediatR;

namespace MerchandiseService.Infrastructure.Commands
{
    public sealed class NewStockCommand : IRequest<bool>
    {
        public int ItemId { get; init; }
        public int Quantity { get; init; }
    }
}

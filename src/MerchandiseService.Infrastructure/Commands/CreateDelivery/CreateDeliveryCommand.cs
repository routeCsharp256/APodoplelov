using System;
using MediatR;

namespace MerchandiseService.Infrastructure.Commands.CreateDelivery
{
    public sealed class CreateDeliveryCommand : IRequest<int>
    {
        public DateTime Date { get; init; }
        public int EmployeeId { get; init; }
        public int MerchPackId { get; init; }
        public byte DeliveryStatus { get; init; }
    }
}

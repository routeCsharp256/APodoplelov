using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.DeliveryAggregate
{
    public sealed class DeliveryStatusEnumeration : Enumeration
    {
        public static readonly DeliveryStatusEnumeration InWork = new DeliveryStatusEnumeration(1, nameof(InWork));
        public static readonly DeliveryStatusEnumeration Done = new DeliveryStatusEnumeration(2, nameof(Done));

        private DeliveryStatusEnumeration(int id, string name) : base(id, name)
        {
        }
    }
}

using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public sealed class ItemEntity : Entity
    {
        public string Name { get; }
        public ItemTypeEnumeration ItemType { get; }
        public SkuValueObject Sku { get; }
        public QuantityValueObject Quantity { get; }

        public ItemEntity(int id, string name,
            ItemTypeEnumeration itemType,
            SkuValueObject sku,
            QuantityValueObject quantity)
        {
            this.Id = id;
            this.Name = name;
            this.ItemType = itemType;
            this.Sku = sku;
            this.Quantity = quantity;
        }
    }
}

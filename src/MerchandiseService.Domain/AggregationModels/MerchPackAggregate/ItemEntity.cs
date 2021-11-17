using System;
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
        public QuantityValueObject Available { get; private set; }

        public ItemEntity(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            this.Id = id;
        }

        public ItemEntity(int id, string name,
            ItemTypeEnumeration itemType,
            SkuValueObject sku,
            QuantityValueObject quantity,
            QuantityValueObject available) : this(id)
        {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentException(nameof(name));
            }

            this.Name = name;

            this.ItemType = itemType ?? throw new ArgumentException(nameof(itemType));

            this.Sku = sku;

            if (null == quantity || quantity.Value < 1) {
                throw new ArgumentException(nameof(quantity));
            }

            this.Quantity = quantity;

            if (null == available || available.Value < 0)
            {
                throw new ArgumentException(nameof(available));
            }

            this.Available = available;
        }

        public void IncreaseAvailable(QuantityValueObject addAvailable) {
            if (addAvailable.Value < 1) {
                throw new ArgumentException(nameof(addAvailable));
            }

            this.Available = new QuantityValueObject(this.Available.Value + addAvailable.Value);
        }
    }
}

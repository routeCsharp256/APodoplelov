using System;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public sealed class MerchPackEntity : Entity
    {
        public MerchTypeEnumeration MerchType { get; set; }
        public string Name { get; set; }
        public ItemEntity[] Items { get; }

        public MerchPackEntity(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            this.Id = id;
        }

        public MerchPackEntity(int id,
            MerchTypeEnumeration merchType,
            string name,
            ItemEntity[] items) : this(id)
        {
            this.MerchType = merchType;

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            this.Name = name;

            if (0 == items.Length) {
                throw new ArgumentException(nameof(items));
            }

            this.Items = items;
        }
    }
}

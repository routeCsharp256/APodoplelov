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
            this.Id = id;
        }

        public MerchPackEntity(int id,
            MerchTypeEnumeration merchType,
            string name,
            ItemEntity[] items
        )
        {
            this.Id = id;
            this.MerchType = merchType;
            this.Name = name;
            this.Items = items;
        }
    }
}

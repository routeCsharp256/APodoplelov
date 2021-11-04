using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public sealed class EmploeeEntity : Entity
    {
        public string Name { get; }

        public EmploeeEntity(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
    }
}

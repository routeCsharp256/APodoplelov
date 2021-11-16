using MerchandiseService.Domain.AggregationModels.ValueObjects;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.DeliveryAggregate
{
    public sealed class EmployeeEntity : Entity
    {
        public string Name { get; }
        public EmailValueObject Email { get; }

        public EmployeeEntity(int id)
        {
            this.Id = id;
        }

        public EmployeeEntity(int id, string name, EmailValueObject email)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
        }
    }
}

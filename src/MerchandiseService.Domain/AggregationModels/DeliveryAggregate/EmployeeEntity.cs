using System;
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
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            this.Id = id;
        }

        public EmployeeEntity(int id, string name, EmailValueObject email) : this(id)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            this.Name = name;

            if (null == email || string.IsNullOrWhiteSpace(email.Value))
            {
                throw new ArgumentException(nameof(email));
            }

            this.Email = email;
        }
    }
}

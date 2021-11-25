using System;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.DeliveryAggregate
{
    public sealed class DeliveryEntity : Entity
    {
        public DateTime Date { get; }
        public EmployeeEntity Employee { get; }
        public MerchPackEntity MerchPack { get; }
        public DeliveryStatusEnumeration DeliveryStatus { get; }

        public DeliveryEntity(
            DateTime date,
            EmployeeEntity employee,
            MerchPackEntity merchPack,
            DeliveryStatusEnumeration deliveryStatus)
        {
            if (default == date)
            {
                throw new ArgumentException(nameof(date));
            }

            this.Date = date;

            this.Employee = employee ?? throw new ArgumentException(nameof(employee));

            this.MerchPack = merchPack ?? throw new ArgumentException(nameof(merchPack));

            this.DeliveryStatus = deliveryStatus ?? throw new ArgumentException(nameof(deliveryStatus));
        }

        public DeliveryEntity(int id,
            DateTime date,
            EmployeeEntity employee,
            MerchPackEntity merchPack,
            DeliveryStatusEnumeration deliveryStatus) : this(date, employee, merchPack, deliveryStatus)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            this.Id = id;
        }
    }
}

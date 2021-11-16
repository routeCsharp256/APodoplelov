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
            this.Date = date;
            this.Employee = employee;
            this.MerchPack = merchPack;
            this.DeliveryStatus = deliveryStatus;
        }

        public DeliveryEntity(int id,
            DateTime date,
            EmployeeEntity employee,
            MerchPackEntity merchPack,
            DeliveryStatusEnumeration deliveryStatus)
        {
            this.Id = id;
            this.Date = date;
            this.Employee = employee;
            this.MerchPack = merchPack;
            this.DeliveryStatus = deliveryStatus;
        }
    }
}

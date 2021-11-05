using System;
using MerchandiseService.Domain.AggregationModels.Entities;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.DeliveryAggregate
{
    public sealed class DeliveryEntity : Entity
    {
        public DateTime Date { get; }
        public EmploeeEntity Emploee { get; }
        public MerchPackEntity MerchPack { get; }
        public DeliveryStatusEnumeration DeliveryStatus { get; }

        public DeliveryEntity(int id,
            DateTime date,
            EmploeeEntity emploee,
            MerchPackEntity merchPack,
            DeliveryStatusEnumeration deliveryStatus)
        {
            this.Id = id;
            this.Date = date;
            this.Emploee = emploee;
            this.MerchPack = merchPack;
            this.DeliveryStatus = deliveryStatus;
        }
    }
}

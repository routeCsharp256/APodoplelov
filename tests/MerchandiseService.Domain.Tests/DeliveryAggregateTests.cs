using System;
using MerchandiseService.Domain.AggregationModels.DeliveryAggregate;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class DeliveryAggregateTests
    {
        [Fact]
        public void TestEmployeeEntityConstructor()
        {
            Assert.Throws<ArgumentException>(() => _ = new EmployeeEntity(0));

            Assert.Throws<ArgumentException>(() => _ = new EmployeeEntity(1, "", null));

            Assert.Throws<ArgumentException>(() => _ = new EmployeeEntity(1, "Test", new EmailValueObject("")));
        }

        [Fact]
        public void TestDeliveryEntityConstructor()
        {
            Assert.Throws<ArgumentException>(() => _ = new DeliveryEntity(0, default, null, null, null));

            Assert.Throws<ArgumentException>(() => _ = new DeliveryEntity(0, DateTime.UtcNow, 
                new EmployeeEntity(1), null, null));

            Assert.Throws<ArgumentException>(() => _ = new DeliveryEntity(0, DateTime.UtcNow,
                new EmployeeEntity(1), 
                new MerchPackEntity(1), null));
        }
    }
}

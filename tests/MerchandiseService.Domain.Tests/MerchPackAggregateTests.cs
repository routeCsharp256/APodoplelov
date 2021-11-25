using System;
using MerchandiseService.Domain.AggregationModels.MerchPackAggregate;
using MerchandiseService.Domain.AggregationModels.ValueObjects;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class MerchPackAggregateTests
    {
        [Fact]
        public void TestItemEntityAddAvailableQuantity()
        {
            var item = new ItemEntity(1, "stock item", ItemTypeEnumeration.Pen, new SkuValueObject(0),
                new QuantityValueObject(1), new QuantityValueObject(2));

            item.IncreaseAvailable(new QuantityValueObject(2));

            Assert.Equal(4, item.Available.Value);
        }

        [Fact]
        public void TestItemEntityConstructor()
        {
            Assert.Throws<ArgumentException>(() => _ = new ItemEntity(0));

            Assert.Throws<ArgumentException>(() => _ = new ItemEntity(1, "", ItemTypeEnumeration.Notepad, null, null, null));

            Assert.Throws<ArgumentException>(() => _ = new ItemEntity(1, "Test entity", ItemTypeEnumeration.Notepad, null, null, null));

            Assert.Throws<ArgumentException>(() => _ = new ItemEntity(1, "Test entity", ItemTypeEnumeration.Notepad, null, 
                new QuantityValueObject(1), null));
        }

        [Fact]
        public void TestMerchPackConstructor() {
            Assert.Throws<ArgumentException>(() => _ = new MerchPackEntity(0));

            Assert.Throws<ArgumentException>(() => _ = new MerchPackEntity(1, MerchTypeEnumeration.VeteranPack, "", Array.Empty<ItemEntity>()));

            Assert.Throws<ArgumentException>(() => _ = new MerchPackEntity(1, MerchTypeEnumeration.VeteranPack, "TestPack", Array.Empty<ItemEntity>()));
        }
    }
}

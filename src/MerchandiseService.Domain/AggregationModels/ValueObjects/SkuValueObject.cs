using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.ValueObjects
{
    public sealed class SkuValueObject : ValueObject
    {
        public long Value { get; }

        public SkuValueObject(long sku)
        {
            Value = sku;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

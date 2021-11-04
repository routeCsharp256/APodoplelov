using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.ValueObjects
{
    public sealed class QuantityValueObject : ValueObject
    {
        public int Value { get; }

        public QuantityValueObject(int quantity)
        {
            this.Value = quantity;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

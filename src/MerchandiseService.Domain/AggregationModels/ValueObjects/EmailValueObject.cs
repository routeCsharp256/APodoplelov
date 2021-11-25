using System.Collections.Generic;
using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.ValueObjects
{
    public sealed class EmailValueObject : ValueObject
    {
        public string Value { get; }

        public EmailValueObject(string address)
        {
            this.Value = address;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}

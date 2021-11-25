using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public sealed class MerchTypeEnumeration : Enumeration
    {
        public static readonly MerchTypeEnumeration WelcomePack = new(1, nameof(WelcomePack));
        public static readonly MerchTypeEnumeration StarterPack = new(2, nameof(StarterPack));
        public static readonly MerchTypeEnumeration ConferencePack = new(3, nameof(ConferencePack));
        public static readonly MerchTypeEnumeration ConferenceSpeakerPack = new(4, nameof(ConferenceSpeakerPack));
        public static readonly MerchTypeEnumeration VeteranPack = new(5, nameof(VeteranPack));

        private MerchTypeEnumeration(int id, string name) : base(id, name)
        {
        }
    }
}

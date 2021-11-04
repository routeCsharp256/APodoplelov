using MerchandiseService.Domain.Models;

namespace MerchandiseService.Domain.AggregationModels.MerchPackAggregate
{
    public sealed class ItemTypeEnumeration : Enumeration
    {
        public static readonly ItemTypeEnumeration TShirt = new(1, nameof(TShirt));
        public static readonly ItemTypeEnumeration Sweatshirt = new(2, nameof(Sweatshirt));
        public static readonly ItemTypeEnumeration Notepad = new(3, nameof(Notepad));
        public static readonly ItemTypeEnumeration Bag = new(4, nameof(Bag));
        public static readonly ItemTypeEnumeration Pen = new(5, nameof(Pen));
        public static readonly ItemTypeEnumeration Socks = new(6, nameof(Socks));

        private ItemTypeEnumeration(int id, string name) : base(id, name)
        {
        }
    }
}

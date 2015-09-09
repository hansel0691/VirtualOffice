using AutoMapper;
using CoreData.Models;
using Domain.Models.Orders;

namespace CoreData.Helpers
{
    public static class MapperHelper
    {
        static MapperHelper()
        {
            Mapper.CreateMap<RawInventoryItem, InventoryItem>()
                .ForMember(item => item.RefId, raw => raw.MapFrom(p => p.thingID))
                .ForMember(item => item.Id, raw => raw.Ignore());
        }

        public static InventoryItem ToDomain(this RawInventoryItem item)
        {
            return Mapper.Map<InventoryItem>(item);
        }
    }
}
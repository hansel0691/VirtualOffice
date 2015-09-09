using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;

namespace VirtualOffice.Data.Repositories
{
    public class InventoryRepository: BaseRepository
    {
        public IEnumerable<sp_get_marketing_materials_Result> GetMarketingMaterials()
        {
            var marketingMaterials = VirtualOfficeContext.sp_get_marketing_materials();

            return marketingMaterials;
        }
    }
}

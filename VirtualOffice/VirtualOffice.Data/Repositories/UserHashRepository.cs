using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;

namespace VirtualOffice.Data.Repositories
{
    public class UserHashRepository: BaseRepository
    {
        public HashKey AddHashKey(HashKey hashKey)
        {
            var result = VirtualOfficeContext.HashKeys.Add(hashKey);

            return result;
        }
    }
}

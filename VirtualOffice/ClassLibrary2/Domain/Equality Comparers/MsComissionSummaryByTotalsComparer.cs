using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary2.Domain.MerchantServices;

namespace ClassLibrary2.Domain.Equality_Comparers
{
    public class MsComissionSummaryByTotalsComparer: IEqualityComparer<MsCommissionSummaryByTotals>
    {
        public bool Equals(MsCommissionSummaryByTotals x, MsCommissionSummaryByTotals y)
        {
            return x.merchantnumber.Equals(y.merchantnumber);
        }

        public int GetHashCode(MsCommissionSummaryByTotals obj)
        {
            return obj.GetHashCode();
        }
    }
}

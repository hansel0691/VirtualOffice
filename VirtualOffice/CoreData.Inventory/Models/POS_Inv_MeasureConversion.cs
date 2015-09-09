using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_MeasureConversion
    {
        public int Source_measureId { get; set; }
        public int Target_MeasureId { get; set; }
        public Nullable<decimal> ConversionFactor { get; set; }
    }
}

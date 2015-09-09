using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_ReadyOrders
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> QueuedDate { get; set; }
        public Nullable<short> Priority { get; set; }
        public Nullable<short> OrderType { get; set; }
        public Nullable<int> Incident { get; set; }
        public string DeployMethod { get; set; }
        public string Merchant { get; set; }
        public string Application { get; set; }
        public Nullable<decimal> TID { get; set; }
        public string Incident_UserName { get; set; }
    }
}

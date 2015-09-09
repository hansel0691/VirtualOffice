using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class vw_Equipments
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<short> EquipType { get; set; }
    }
}

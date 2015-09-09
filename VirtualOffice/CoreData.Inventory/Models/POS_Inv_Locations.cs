using System;
using System.Collections.Generic;

namespace CoreData.Inventory.Models
{
    public partial class POS_Inv_Locations
    {
        public POS_Inv_Locations()
        {
            this.POS_Inv_Entries = new List<POS_Inv_Entries>();
            this.POS_Inv_Items = new List<POS_Inv_Items>();
            this.POS_Inv_LocationHistory = new List<POS_Inv_LocationHistory>();
            this.POS_Inv_Replacements = new List<POS_Inv_Replacements>();
            this.POS_Inv_Returns = new List<POS_Inv_Returns>();
            this.POS_Inv_Rotations = new List<POS_Inv_Rotations>();
            this.POS_Inv_Rotations1 = new List<POS_Inv_Rotations>();
            this.POS_Inv_Sales = new List<POS_Inv_Sales>();
            this.POS_Inv_Sustitutions = new List<POS_Inv_Sustitutions>();
        }

        public int locationID { get; set; }
        public string lcDescription { get; set; }
        public string lcAddressFirstLine { get; set; }
        public string lcAddressSecondLine { get; set; }
        public string lcCity { get; set; }
        public string lcState { get; set; }
        public string lcZip { get; set; }
        public string lcPhone { get; set; }
        public string lcFax { get; set; }
        public string lcContact { get; set; }
        public string lcEMail { get; set; }
        public Nullable<int> lcType { get; set; }
        public Nullable<int> lcStatus { get; set; }
        public virtual ICollection<POS_Inv_Entries> POS_Inv_Entries { get; set; }
        public virtual ICollection<POS_Inv_Items> POS_Inv_Items { get; set; }
        public virtual ICollection<POS_Inv_LocationHistory> POS_Inv_LocationHistory { get; set; }
        public virtual ICollection<POS_Inv_Replacements> POS_Inv_Replacements { get; set; }
        public virtual ICollection<POS_Inv_Returns> POS_Inv_Returns { get; set; }
        public virtual ICollection<POS_Inv_Rotations> POS_Inv_Rotations { get; set; }
        public virtual ICollection<POS_Inv_Rotations> POS_Inv_Rotations1 { get; set; }
        public virtual ICollection<POS_Inv_Sales> POS_Inv_Sales { get; set; }
        public virtual ICollection<POS_Inv_Sustitutions> POS_Inv_Sustitutions { get; set; }
    }
}

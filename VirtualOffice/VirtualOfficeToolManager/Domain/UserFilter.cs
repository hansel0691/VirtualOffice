using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace VirtualOfficeToolManager.Domain
{
    public class UserFilter: Filter
    {
        public string Label { get; set; }

        public string FilterOptions { get; set; }
        
    }
}

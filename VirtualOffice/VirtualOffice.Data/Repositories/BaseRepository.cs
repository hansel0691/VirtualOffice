using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;

namespace VirtualOffice.Data.Repositories
{
    public class BaseRepository
    {
        protected VirtualOfficeEntities VirtualOfficeContext { get; set; }

        public BaseRepository()
        {
            VirtualOfficeContext = new VirtualOfficeEntities();
        }

        public void SaveChanges()
        {
            VirtualOfficeContext.SaveChanges();
        }

    }
}

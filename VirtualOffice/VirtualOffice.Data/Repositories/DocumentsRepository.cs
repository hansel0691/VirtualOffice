using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;

namespace VirtualOffice.Data.Repositories
{
    public class DocumentsRepository: BaseRepository
    {
        public IEnumerable<sp_retrieve_documents_Result> GetAllDocuments()
        {
            var documents = VirtualOfficeContext.sp_retrieve_documents(null);

            return documents;
        }
    }
}

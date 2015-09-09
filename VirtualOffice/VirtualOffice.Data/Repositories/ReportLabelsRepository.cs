using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;

namespace VirtualOffice.Data.Repositories
{
    public class ReportLabelsRepository: BaseRepository
    {
        public IEnumerable<ReportLabel> GetReportLabels(string storeProcedureName)
        {
            var reportLabels = VirtualOfficeContext.ReportLabels.Where(r=> r.Report.Query == storeProcedureName);

            return reportLabels;
        }
    }
}

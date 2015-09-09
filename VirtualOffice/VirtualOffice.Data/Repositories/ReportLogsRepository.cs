using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;

namespace VirtualOffice.Data.Repositories
{
    public class ReportLogsRepository: BaseRepository
    {
        public void LogReportResult(ReportLog reportLog)
        {
            VirtualOfficeContext.ReportLogs.Add(reportLog);

            SaveChanges();
        }
    }
}

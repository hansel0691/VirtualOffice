using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;

namespace VirtualOffice.Data.Repositories
{
    public class DashboardConfigsRepository: BaseRepository
    {
        public IEnumerable<DashboardConfig> GetDashboardConfigs()
        {
            var allDashBoardConfigs = VirtualOfficeContext.DashboardConfigs;

            return allDashBoardConfigs;
        }

        public IEnumerable<DashboardConfig> GetDashboardConfigs(string type)
        {
            var allConfigs = GetDashboardConfigs();

            var result = allConfigs.Where(c => c.DashboardItemType == type);

            return result;
        }
    }
}

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VirtualOffice.Data.EFModels;
using VirtualOffice.Data.Helpers;

namespace VirtualOffice.Data.Repositories
{
    public class UserReportRepository: BaseRepository
    {
        public UserReport GetUserReport(int agentId, string storeProcedureName)
        {
            var userId = GetUserId(agentId);

            var searchResult =
                VirtualOfficeContext.UserReports.FirstOrDefault(
                    userReport => userReport.Report.Query.Equals(storeProcedureName) && userReport.UserId == userId);
            
            if (searchResult == null)
                searchResult = AddNewUserReport(userId, storeProcedureName);
            return searchResult;

        }

        public void UpdateUserReportOutPut(int agentId, string storeProcedureName, string userReportOutput)
        {
            var userId = GetUserId(agentId);

            var userReport = VirtualOfficeContext.UserReports.FirstOrDefault(ur => ur.Report.Query.Equals(storeProcedureName) && ur.UserId.Equals(userId));

            if (userReport != null)
            {
                userReport.Output = userReportOutput;

                SaveChanges();
            }
        }

        public void UpdateUserReportOutPutConfig(int agentId, string storeprocedureName, string outputConfiguration)
        {
            var userId = GetUserId(agentId);

            var userReport =
                VirtualOfficeContext.UserReports.FirstOrDefault(
                    ur => ur.Report.Query.Equals(storeprocedureName) && ur.UserId == userId);
            
            if (userReport != null)
            {
                userReport.OutputConfiguration = outputConfiguration;
                SaveChanges();
            }
        }

        #region Aux Ops

        private UserReport AddNewUserReport(int agentId, string storeProcedureName)
        {
            var report = VirtualOfficeContext.Reports.FirstOrDefault(rep => rep.Query.Equals(storeProcedureName));

            if (report == null)
                report = AddNewReport(storeProcedureName);

            var userReport = new UserReport
            {
                UserId = agentId,
                ReportId = report.Id,
                Output = report.Output,
                TimeSpan = DateTime.Now,
                RowVersion = Helper.GetVersionRow(),
                ExecutionCount = 0,
                RowCount = 0,
                OutputConfiguration = GetDefaultOutputConfigForSameReport(storeProcedureName),
                ShouldBeShownAtDesktop = false
            };

            var userReportResult = VirtualOfficeContext.UserReports.Add(userReport);

            SaveChanges();

            return userReportResult;
        }

        private string GetDefaultOutputConfigForSameReport(string storeProcedureName)
        {
            var searchResult =
             VirtualOfficeContext.UserReports.FirstOrDefault(
                 userReport => userReport.Report.Query.Equals(storeProcedureName));

            //Another already defined is taken (the very first one is defined manually because of the level part)
            return searchResult != null ? searchResult.OutputConfiguration : GetJsonDefaultOutPutConfig(storeProcedureName);
        }

        private string GetJsonDefaultOutPutConfig(string storeProcedureName)
        {
            try
            {
                var report = VirtualOfficeContext.Reports.FirstOrDefault(rep => rep.Query.Equals(storeProcedureName));

                var columnsConfig = report.Output.Split(',').Select((a, i) => new
                {
                    Name = a,
                    Width = 120,
                    Index = i,
                    Level = 0
                });

                var columnsConfigSerialized = JsonConvert.SerializeObject(columnsConfig);

                return columnsConfigSerialized;
            }
            catch (Exception exception)
            {
                return string.Empty;
            }
        }

        private Report AddNewReport(string storeProcedureName)
        {
            var newReport = new Report
            {
                Query = storeProcedureName,
                Name = storeProcedureName,
                Output = GetCommaSeparatedOutput(storeProcedureName),
                DefaultOutput = GetCommaSeparatedOutput(storeProcedureName),
                RowVersion = Helper.GetVersionRow(),
                IsStandAlone = false,
                TimeSpan = DateTime.Now,
                IsEnable = false
            };

            var report = VirtualOfficeContext.Reports.Add(newReport);

            SaveChanges();

            return report;
        }

        private IEnumerable<string> GetReportDefaultResult(string storeProcedureName)
        {
            var assembly = typeof(VirtualOfficeEntities).Assembly;

            var className = storeProcedureName + "_Result";

            var allClasses = assembly.GetTypes();

            var classInstance = allClasses.FirstOrDefault(cl => cl.Name.Equals(className));

            var allProperties = classInstance == null ? new List<string>() : classInstance.GetProperties().Select(prop => prop.Name);

            return allProperties;

        }

        private string GetCommaSeparatedOutput(string storeProcedureName)
        {
            var tokens = GetReportDefaultResult(storeProcedureName);

            if (tokens == null)
                return string.Empty;

            tokens = tokens.Where(st => !string.IsNullOrEmpty(st.ToString()));

            if (!tokens.Any())
                return string.Empty;

            var result = tokens.Aggregate(string.Empty, (current, token) => current + (token + ","));

            return result.Remove(result.Length - 1);
        }

        private int GetUserId(int agentId)
        {
            var user = VirtualOfficeContext.Users.FirstOrDefault(u => u.RefId == agentId);

            return user != null ? user.Id : 0;
        }
        #endregion


        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using CoreData.Contexts;
using Domain.Infrastructure.Repositories;
using Domain.Models;
using Domain.Models.Exceptions;

namespace CoreData.Concrete
{
    public class SqlReportInfoRepository :  IReportInfoRepository
    {
        private readonly VirtualOfficeContext context;

        public SqlReportInfoRepository(VirtualOfficeContext context)
        {
            this.context = context;
        }

        public IEnumerable<Parameter> GetReportParams(string query)
        {
            try
            {
                IEnumerable<Parameter> parameters = context.GetParameterFromStoredProcedure(query);

                if (parameters == null)
                {
                    return Enumerable.Empty<Parameter>();
                }

                return parameters.ToArray();

            }
            catch (Exception e)
            {
                throw new DataAccessException("See inner exception", e);
            }
        }

        public IEnumerable<UserReport> GetUserReports(int userId)
        {
            try
            {
                IEnumerable<UserReport> reports = context.UserReports.Where(report => report.User.RefId == userId);

                return reports;

            }
            catch (Exception e)
            {
                throw new DataAccessException("See inner exception", e);
            }
        }
    }
}

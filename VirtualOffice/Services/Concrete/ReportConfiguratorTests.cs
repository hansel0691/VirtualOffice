using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Services.Concrete
{
    [TestClass]
    public class ReportConfiguratorTests
    {
        //[TestMethod]
        //[ExpectedException(typeof (ReportExecuterException))]
        //public void empty_query()
        //{
        //    ReportConfigurator configurator = new ReportConfigurator(
        //        new ReportExecuter(new SqlQueryExecutor(), new SqlUserReportRepository(), new ReportOutputParser()), new SqlReportInfoRepository());

        //    var schema = configurator.GetReportSchema("Test").ToArray();
        //}

        //[TestMethod]
        //public void get_parameters()
        //{
        //    var x = new SqlReportInfoRepository();

        //    var p = x.GetReportParams("sp_acc_sales_report_by_product");


        //}

        //[TestMethod]
        //public void run_query_with_param()
        //{
        //    var x = new ReportExecuter(new SqlQueryExecutor(),new SqlUserReportRepository(),new ReportOutputParser());

        //    var result = x.Execute("sp_acc_sales_report_by_product", new Argument { Param = new Parameter { Name = "@prd_info" }, Value = 500060 });
        //}
    }
}
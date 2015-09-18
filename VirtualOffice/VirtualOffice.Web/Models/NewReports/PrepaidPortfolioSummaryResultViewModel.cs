using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualOffice.Web.Models.NewReports
{
    public class PrepaidPortfolioSummaryResultViewModel
    {
        public int? MID { get; set; }
        public string BillAgentName { get; set; }
        public string DistName { get; set; }
        public string Alert { get; set; }
        public string business_name { get; set; }
        public string business_address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Opened { get; set; }
        public string acc_type { get; set; }
        public string p_plan { get; set; }
        public string service_type { get; set; }
        public string weekly_credit_limit { get; set; }
        public string daily_credit_limit { get; set; }
        public string Balance { get; set; }
        public int returned_achs { get; set; }
        public string Status { get; set; }
//        public bool Status { get; set; }
        public string suspended_reason { get; set; }
        public string connection_type { get; set; }
        public string bill_payment { get; set; }
        public string prepaid_tolls { get; set; }
        public string last_sale { get; set; }
        public double last_month_sales { get; set; }
        public double this_month_sales { get; set; }
        public double seven_day_sales { get; set; }
        public double today_sales { get; set; }
        public string software_version { get; set; }
        public string profile_date { get; set; }
        public string is_ach_active { get; set; }
        public string top_selling_product { get; set; }
        public int sort_order { get; set; }
    }
}
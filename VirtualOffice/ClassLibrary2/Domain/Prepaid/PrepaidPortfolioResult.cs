﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualOffice.Data.EFModels;

namespace ClassLibrary2.Domain.Prepaid
{
    public class PrepaidPortfolioResult
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
        public string suspended_reason { get; set; }
        public string connection_type { get; set; }
        public string bill_payment { get; set; }
        public string prepaid_tolls { get; set; }
        public string last_sale { get; set; }
        public string last_month_sales { get; set; }
        public string this_month_sales { get; set; }
        public string seven_day_sales { get; set; }
        public string today_sales { get; set; }
        public string software_version { get; set; }
        public string profile_date { get; set; }
        public string is_ach_active { get; set; }
        public string top_selling_product { get; set; }
        public int sort_order { get; set; }
        public bool suspended { get; set; }
        public bool? compliance { get; set; }
        public int closed { get; set; }



        public UserStatus UserStatus
        {
            get
            {
                if (closed == 0 && !suspended)
                    return UserStatus.Active;
                if (closed == 1) return UserStatus.Close;
                return UserStatus.Suspended;
            }
            set
            {
                switch (value)
                {
                    case UserStatus.Close:
                        closed = 1;
                        suspended = false;
                        break;
                    case UserStatus.Active:
                        closed = 0;
                        suspended = false;
                        break;
                    default:
                        closed = 0;
                        suspended = true;
                        break;
                }
            }
        }
    }


    public enum UserStatus
    {
        Active,
        Suspended,
        Close,
    }

}

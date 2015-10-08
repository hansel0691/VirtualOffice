using System;
using System.Collections.Generic;
using System.Linq;
using VirtualOffice.Web.Models.NewReports;
using System.Web;
using System.Web.Mvc;

namespace VirtualOffice.Web.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static IHtmlString MerchantIdentifier(this HtmlHelper htmlHelper, SalesAgentMerchantSalesResultViewModel item)
        {
            var pk = item.Merchant_Pk.ToString();
            var name = item.Mer_Name;
            var dba = string.IsNullOrWhiteSpace(item.Merchant_dba) ? "" : "<span>" + item.Merchant_dba + "</span>";
            var city = item.City;
            var state = item.State;
            var zip = item.ZIP;
            var dirty = item.IsClosed || item.compliance || item.suspended || item.isCollection;
            var merchantTypeStatusIcon = "/Content/img/";
            var noSalesImg = item.DaysSinceLastSale > 1 ? "<img src='/Content/img/icon_no_sales.gif' alt='No Sales Transactions registered in last 24 + hours' border='0'/>" : "";

            switch (@item.MerType)
            {
                case 0:
                    merchantTypeStatusIcon += dirty ? "inv_pos_closed.gif" : "inv_pos.gif";
                    break;
                case 1:
                    merchantTypeStatusIcon += dirty ? "inv_portal_closed.gif" : "inv_portal.gif";
                    break;
                case 3:
                    merchantTypeStatusIcon += dirty ? "inv_touchandgo_closed.gif" : "inv_touchandgo.gif";
                    break;
                case 4:
                    merchantTypeStatusIcon += dirty ? "inv_tnbcom_closed.gif" : "inv_tnbcom.gif";
                    break;
                default:
                    merchantTypeStatusIcon += dirty ? "inv_tnbcom.gif" : "inv_ok.gif";
                    break;
            }

            var identifier = string.Format("<span class='no-wrap'><img src='{6}'/>[{0}] <b>{1}</b> {7}</span>{2}<span>{3}, {4} {5}</span>", pk, name, dba, city, state, zip, merchantTypeStatusIcon, noSalesImg);
            return MvcHtmlString.Create(identifier);
        }

        public static IHtmlString DisplayCurrency(this HtmlHelper htmlHelper, double value)
        {
            var result = string.Format("<div class='numeric'>{0}</div>", value.ToString("C2"));
            return MvcHtmlString.Create(result);
        }

    }
}
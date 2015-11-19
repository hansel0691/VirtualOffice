using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;
using ApiRestClient.Infrastructure;
using System.Net.Mail;
using System.Net;
using Mvc.Mailer;

namespace VirtualOffice.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class ManagerController : VirtualOfficeController
    {

        public ManagerController(IWebClient webClient) : base(webClient)
        {
        }


        public ActionResult CreateAccount(string msg)
        {
            var user = Session[Utils.UserKey] as UserModel;

            if (!user.IsFullcarga)
                return RedirectToAction("Index", "Reports");

            var model = new MerchantCreationModel();
            ViewBag.Message = msg;
            ViewBag.AllStates = GetAllStates();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateAccount(MerchantCreationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = Session[Utils.UserKey] as UserModel;

                var businessName = model.BusinessName;
                var businessPhone = model.BusinessPhone;
                var businessFax = model.BusinessFax;
                var dba = model.DBA;
                var emailAddress = model.Email;
                var cellularNumber = model.CellPhone;
                var businessStreet = model.BusinessStreet;
                var businessCity = model.BusinessCity;
                var businessState = model.BusinessStreet;
                var businessZip = model.BusinessZip;
                var merchant_MainContactPhone = model.GuarantorPhone;
                var merchant_MainContact = model.GuarantorName;
                var merchant_RepId = user.UserId;
                var repName = user.Name;

                var reportData = _virtualOfficeService.CreatePosPendingMerchants(businessName, businessPhone, businessFax, dba, emailAddress, cellularNumber, businessStreet, businessCity, businessState, businessZip, merchant_MainContactPhone, merchant_MainContact, merchant_RepId, repName);

                if (reportData)
                {
                    SendConfirmationEmails();
                    var msg = string.Format("The merchant {0} has been added to our systems and is pending for approval.", businessName);
                    return RedirectToAction("CreateAccount", new { msg = msg });
                }
            }
            ViewBag.Error = "There was an error trying to add the new merchant. Please check the information and try again.";
            ViewBag.AllStates = GetAllStates();
            return View(model);
            
        }

        private void SendConfirmationEmails()
        {
            try
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var mailer = new MailerBase();
                var fromEmailId = @System.Configuration.ConfigurationManager.AppSettings["mailId"];
                var toEmailId = @System.Configuration.ConfigurationManager.AppSettings["mailToCC"];
                //var ccEmailId = @System.Configuration.ConfigurationManager.AppSettings["mailTo"];

                var email = mailer.Populate(x =>
                {
                    x.From = new MailAddress(fromEmailId);
                    x.Subject = "Creation of New Merchant In Systems";
                    x.To.Add(toEmailId);
                    x.Body = body;
                    x.IsBodyHtml = true;
                    x.ViewName = "Confirmation";
                });
                email.Send();
            }
            catch (Exception e)
            {
                return;
            }
        }

        private SelectList GetAllStates()
        {
            var states = new List<string>()
            {
                "Alabama",
                "Alaska",
                "Arizona",
                "Arkansas",
                "California",
                "Colorado",
                "Connecticut",
                "Delaware",
                "District Of Columbia",
                "Florida",
                "Georgia",
                "Hawaii",
                "Idaho",
                "Illinois",
                "Indiana",
                "Iowa",
                "Kansas",
                "Kentucky",
                "Louisiana",
                "Maine",
                "Maryland",
                "Massachusetts",
                "Michigan",
                "Minnesota",
                "Mississippi",
                "Missouri",
                "Montana",
                "Nebraska",
                "Nevada",
                "New Hampshire",
                "New Jersey",
                "New Mexico",
                "New York",
                "North Carolina",
                "North Dakota",
                "Ohio",
                "Oklahoma",
                "Oregon",
                "Pennsylvania",
                "Rhode Island",
                "South Carolina",
                "South Dakota",
                "Tennessee",
                "Texas",
                "Utah",
                "Vermont",
                "Virginia",
                "Washington",
                "West Virginia",
                "Wisconsin",
                "Wyoming"
            };
            return new SelectList(states);
        }
    }

}
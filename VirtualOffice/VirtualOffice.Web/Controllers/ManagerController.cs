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

namespace VirtualOffice.Web.Controllers
{
    [Authorize(Roles = "User")]
    public class ManagerController : VirtualOfficeController
    {

        public ManagerController(IWebClient webClient) : base(webClient)
        {
        }


        public ActionResult CreateAccount()
        {
            var user = Session[Utils.UserKey] as UserModel;

            if (!user.IsFullcarga)
                return RedirectToAction("Index", "Reports");

            var model = new MerchantCreationModel();

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
                }
                return RedirectToAction("Index", "Report");
            }
            return View(model);
            
        }

        private void SendConfirmationEmails()
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("hgarcia@blackstoneonline.com")); 
            //message.To.Add(new MailAddress("svaras@nopin.us")); 
            message.From = new MailAddress("sender@outlook.com"); 
            message.Subject = "Creation of New Merchant In systems";
            message.Body = "A new merchant has been created.";
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "user@outlook.com",  // replace with valid value
                    Password = "password"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.SendMailAsync(message);
            }
        }
    }

}
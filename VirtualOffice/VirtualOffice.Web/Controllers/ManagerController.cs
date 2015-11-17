using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;
using ApiRestClient.Infrastructure;

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
            return null;
        }

    }
}
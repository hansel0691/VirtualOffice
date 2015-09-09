using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Domain.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using RestSharp.Serializers;
using VirtualOffice.Web.Infrastructure;
using VirtualOffice.Web.Models;
using ApiRestClient.Infrastructure;
using RestSharp;
using FilterType = Domain.Models.FilterType;

namespace VirtualOffice.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebClient _webClient;


        public HomeController(IWebClient webClient)
        {
            _webClient = webClient;
        }

        public ActionResult Index()
        {
            return View();
        }

    }

}
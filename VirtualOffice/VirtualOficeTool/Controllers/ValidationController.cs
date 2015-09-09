using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VirtualOfficeToolManager;

namespace VirtualOficeTool.Controllers
{
    public class ValidationController : Controller
    {

       private readonly OfficeToolManager _virtualOfficeToolManager;

       public ValidationController()
        {
            _virtualOfficeToolManager = new OfficeToolManager();
        }

        public JsonResult IsReportNameAvailable(string Name)
        {
            var reportNameAvailable = _virtualOfficeToolManager.IsReportNameAvailable(Name); 

                return Json(reportNameAvailable, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult IsFilterNameAvailable(string Name)
        //{
        //    var filterNameAvailable = _virtualOfficeToolManager.IsFilterNameAvailable(Name);

        //    return Json(filterNameAvailable, JsonRequestBehavior.AllowGet);
            
        //}

    }
}

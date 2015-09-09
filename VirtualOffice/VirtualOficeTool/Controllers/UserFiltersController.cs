using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using VirtualOfficeToolManager;
using VirtualOfficeToolManager.Domain;
using VirtualOficeTool.Models;

namespace VirtualOficeTool.Controllers
{
    public class UserFiltersController : Controller
    {
        private readonly OfficeToolManager _virtualOfficeToolManager;

        public UserFiltersController()
        {
            _virtualOfficeToolManager = new OfficeToolManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult GetUserFilters(DataSourceRequest request)
        //{
        //    try
        //    {
        //        var userFilters = _virtualOfficeToolManager.GetUserFilters();

        //        return Json(userFilters.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}

        //[HttpPost]
        //public ActionResult AddNewUserFilter(UserFilterViewModel userFilterViewModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //            return View("Index", userFilterViewModel);

        //        var userFilter = new UserFilter()
        //        {
        //            Label = userFilterViewModel.Label,
        //            Name = userFilterViewModel.Name,
        //            FilterOptions = userFilterViewModel.FieldName
        //        };

        //        _virtualOfficeToolManager.AddNewUserFilter(userFilter);

        //        return RedirectToAction("Index");
        //    }
        //     catch (Exception exception)
        //    {
        //        ModelState.AddModelError("","Errors while trying to add a new User Filter. Please, try again later! :)");

        //        return View("Index", userFilterViewModel);
        //    }
        //}

        //public ActionResult UpdateUserFilter(UserFilterViewModel userFilterViewModel)
        //{
        //    try
        //    {
        //        var userFilter = new UserFilter()
        //        {
        //            Id = userFilterViewModel.Id,
        //            Label = userFilterViewModel.Label,
        //            Name = userFilterViewModel.Name,
        //            FilterOptions = userFilterViewModel.FieldName
        //        };

        //        _virtualOfficeToolManager.UpdateUserFilter(userFilter);

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError("", "Errors while trying to update the  User Filter. Please, try again later! :)");

        //        return View("Index", userFilterViewModel);
        //    }
            
        //}

        //public ActionResult RemoveUserFilter(UserFilterViewModel userFilterViewModel)
        //{
        //    try
        //    {
        //        _virtualOfficeToolManager.RemoveUserFilter(userFilterViewModel.Id);

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {
        //        ModelState.AddModelError("", "Errors while trying to remove the  User Filter. Please, try again later! :)");

        //        return View("Index", userFilterViewModel);
        //    }

        //}

    }
}

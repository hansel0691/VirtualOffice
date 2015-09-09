
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using VirtualOfficeToolManager;
using VirtualOfficeToolManager.Domain;
using VirtualOficeTool.Infrastructure;
using VirtualOficeTool.Models;

namespace VirtualOficeTool.Controllers
{
    public class PredefinedFiltersController : Controller
    {
        private readonly OfficeToolManager _virtualOfficeToolManager;

        public PredefinedFiltersController()
        {
            _virtualOfficeToolManager = new OfficeToolManager();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPredefinedFilters(DataSourceRequest request)
        {
            try
            {
                var predefinedFilters = _virtualOfficeToolManager.GetPredefinedFilters();

                var predefinedFiltersResult = predefinedFilters.MapTo<IEnumerable<PredefinedFilter>, IEnumerable<PredefinedFilterViewModel>>();

                return Json(predefinedFiltersResult.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ActionResult AddNewPredefinedFilter(PredefinedFilterViewModel predefinedFilterViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Index", predefinedFilterViewModel);

                var userFilter = new PredefinedFilter()
                {
                    Name = predefinedFilterViewModel.Name,
                    Type = predefinedFilterViewModel.Type == "Column" ? 0 : 1,
                    Value = predefinedFilterViewModel.Value,
                    ColumnName = predefinedFilterViewModel.ColumnName,
                    ParameterName = predefinedFilterViewModel.ParameterName
                };

                _virtualOfficeToolManager.AddNewPredefinedFilter(userFilter);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", "Errors while trying to add a new Predefined Filter. Please, try again later! :)");

                return View("Index", predefinedFilterViewModel);
            }
        }

        public ActionResult UpdatePredefinedFilter(PredefinedFilterViewModel predefinedFilterViewModel)
        {
            try
            {
                

                var predefinedFilter = new PredefinedFilter()
                {
                    Id= predefinedFilterViewModel.Id,
                    Name = predefinedFilterViewModel.Name,
                    Type = predefinedFilterViewModel.Type == "Column" ? 0 : 1,
                    Value = predefinedFilterViewModel.Value,
                    ColumnName = predefinedFilterViewModel.ColumnName,
                    ParameterName = predefinedFilterViewModel.ParameterName
                };

                _virtualOfficeToolManager.UpdatePredefinedFilter(predefinedFilter);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Errors while trying to update the Predefined Filter. Please, try again later! :)");

                return View("Index", predefinedFilterViewModel);
            }

        }

        public ActionResult RemovePredefinedFilter(PredefinedFilterViewModel userFilterViewModel)
        {
            try
            {
                _virtualOfficeToolManager.RemovePredefinedFilter(userFilterViewModel.Id);

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Errors while trying to remove the  Predefined Filter. Please, try again later! :)");

                return View("Index", userFilterViewModel);
            }

        }

    }
}

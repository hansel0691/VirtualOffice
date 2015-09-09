using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using VirtualOfficeToolManager.Data;
using VirtualOficeTool.Models;
using Report = VirtualOfficeToolManager.Domain.Report;
using UserFilter = VirtualOfficeToolManager.Domain.UserFilter;

namespace VirtualOficeTool.Infrastructure
{
    static public class ConverterHelper
    {
        static ConverterHelper()
        {
            InitMaps();
        }


        private static void InitMaps()
        {

            #region Filters

            Mapper.CreateMap<VirtualOfficeToolManager.Domain.UserFilter, UserFilterViewModel>();
            Mapper.CreateMap<VirtualOfficeToolManager.Domain.PredefinedFilter, PredefinedFilterViewModel>().
                ForMember(p => p.Type, t => t.ResolveUsing(s=> s.Type==0? "Column":"Value"));
            #endregion

            #region Reports

            Mapper.CreateMap<ReportViewModel, Report>().
                ForMember(p => p.TimeSpan, t => t.ResolveUsing(a => DateTime.Now)).
                ForMember(p => p.OutPut, t => t.MapFrom(q => GetCommaSeparatedTokens(q.OutPut))).
                ForMember(p => p.ColumnLabels, t => t.MapFrom(q => GetCommaSeparatedTokens(q.ColumnLabels))).
                ForMember(p => p.UserFilters, t => t.MapFrom(q => GetCommaSeparatedTokens(q.UserFilters))).
                ForMember(p => p.Levels, t => t.MapFrom(q => GetCommaSeparatedTokens(q.Levels))).
                ForMember(p => p.ParamsDefaultConfiguration, t => t.MapFrom(q => GetCommaSeparatedTokens(q.Parameter)));
            Mapper.CreateMap<Report, ReportViewModel>();

            Mapper.CreateMap<Report, SubReportViewModel>().
            ForMember(p => p.ColumnName, t => t.ResolveUsing(p=> string.Empty));

            #endregion
        }

        public static K MapTo<T, K>(this T aModelSource)
        {
            var modelResult = Mapper.Map<T, K>(aModelSource);

            return modelResult;
        }

        public static bool IsNull<T>(this T item)
        {
            return item == null;
        }

        public static string GetCommaSeparatedTokens<T>(this IEnumerable<T> tokens)
        {
            if (tokens.IsNull())
                return string.Empty;

            tokens = tokens.Where(st => !string.IsNullOrEmpty(st.ToString()));

            if (!tokens.Any())
                return string.Empty;

            var result = tokens.Aggregate(string.Empty, (current, token) => current + (token + ","));

            return result.Remove(result.Length - 1);
        }

    }
    public static class Helper
    {
        public static string GetViewContent(this Controller controller, string viewName, object model)
        {
            var controllerContext = controller.ControllerContext;

            if (string.IsNullOrWhiteSpace(viewName))
                //Return name of view for current action
                viewName = controllerContext.RouteData.GetRequiredString("action");

            controllerContext.Controller.ViewData.Model = model;
            using (var stringWriter = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
                var viewContext = new ViewContext(controllerContext, viewResult.View, controllerContext.Controller.ViewData, controllerContext.Controller.TempData, stringWriter);
                viewResult.View.Render(viewContext, stringWriter);

                return stringWriter.GetStringBuilder().ToString();
            }
        }   
    }
}
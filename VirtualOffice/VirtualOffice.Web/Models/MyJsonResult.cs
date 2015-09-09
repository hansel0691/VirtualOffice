using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VirtualOffice.Web.Models
{
    public class MyJsonResult: ActionResult
    {
        private string stringAsJson;

        public MyJsonResult(string stringAsJson)
        {
            this.stringAsJson = stringAsJson;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var httpCtx = context.HttpContext;
            httpCtx.Response.ContentType = "application/json";
            httpCtx.Response.Write(stringAsJson);
        }
    }
}
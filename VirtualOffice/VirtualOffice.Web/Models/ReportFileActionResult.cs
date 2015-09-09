using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VirtualOffice.Web.Models
{
    /// Created By: Carlos Raul (03112014)
    /// <summary>
    /// 
    /// </summary>
    public class ReportFileActionResult : ActionResult
    {

        public GridView ExcelGridView { get; set; }
        public string FileName { get; set; }


        public ReportFileActionResult(GridView gridView, string pFileName)
        {
            ExcelGridView = gridView;
            FileName = pFileName;
        }

        public override void ExecuteResult(ControllerContext context)
        {

            //Create a response stream to create and write the Excel file
            var curContext = HttpContext.Current;
            curContext.Response.Clear();
            curContext.Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            curContext.Response.Charset = "";
            curContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            curContext.Response.ContentType = "application/vnd.ms-excel";

            //Convert the rendering of the gridview to a string representation 
            var sw = new StringWriter();
            var htw = new HtmlTextWriter(sw);
            ExcelGridView.RenderControl(htw);

            //Open a memory stream that you can use to write back to the response
            var byteArray = Encoding.ASCII.GetBytes(sw.ToString());
            var s = new MemoryStream(byteArray);
            var sr = new StreamReader(s, Encoding.ASCII); 
 
            //Write the stream back to the response
            curContext.Response.Write(sr.ReadToEnd());
            curContext.Response.End();

        }

    } 
}
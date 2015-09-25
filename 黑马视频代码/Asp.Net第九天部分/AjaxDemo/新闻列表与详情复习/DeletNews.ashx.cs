using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News.BLL;

namespace Demo.新闻列表与详情复习
{
    /// <summary>
    /// DeletNews 的摘要说明
    /// </summary>
    public class DeletNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id = int.Parse(context.Request["id"] ?? "0");
            HKSJ_Main bllMain = new HKSJ_Main();
            bllMain.Delete(id);
            context.Response.Write("ok");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
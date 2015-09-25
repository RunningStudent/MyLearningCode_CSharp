using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.用datagrid进行增删改查
{
    /// <summary>
    /// AddNews 的摘要说明
    /// </summary>
    public class AddNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            News.Model.HKSJ_Main modelMain = new News.Model.HKSJ_Main();
            modelMain.title = context.Request["title"];
            modelMain.picUrl = "";
            modelMain.people = context.Request["people"];
            modelMain.type = context.Request["type"];
            modelMain.content = context.Request["content"];
            modelMain.Date = DateTime.Now;

            News.BLL.HKSJ_Main bllMain = new News.BLL.HKSJ_Main();
            bllMain.Add(modelMain);
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
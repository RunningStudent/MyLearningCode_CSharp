using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.用AJax显示_编辑新闻列表
{
    /// <summary>
    /// AddNews 的摘要说明
    /// </summary>
    public class AddNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            News.Model.HKSJ_Main modelMain = new News.Model.HKSJ_Main();

            modelMain.people = context.Request["txtPeople"];
            modelMain.title = context.Request["txtTitle"];
            modelMain.content = context.Request["txtContent"];
            modelMain.Date = DateTime.Now;
            modelMain.picUrl = string.Empty;
            modelMain.type = string.Empty;

            News.BLL.HKSJ_Main BllMain = new News.BLL.HKSJ_Main();
            if (BllMain.Add(modelMain) > 0)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("error");
            }




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
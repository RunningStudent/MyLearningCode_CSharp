using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.用datagrid进行增删改查
{
    /// <summary>
    /// DeleteNews 的摘要说明
    /// </summary>
    public class DeleteNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string ids = context.Request["id"];
            
            //delete from xxxx where id in(xx,xx,xx)
            News.BLL.HKSJ_Main bllMain = new News.BLL.HKSJ_Main();
            bllMain.DeleteList(ids);
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
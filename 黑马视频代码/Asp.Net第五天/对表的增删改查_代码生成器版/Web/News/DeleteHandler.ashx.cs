using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News;
using News.Model;
namespace News.Web.News
{
    /// <summary>
    /// DeleteHandler 的摘要说明
    /// </summary>
    public class DeleteHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //获取id
            int id;
            int.TryParse(context.Request["id"].ToString(),out id);

            //删除数据
            BLL.Main mainBll = new BLL.Main();
            mainBll.Delete(id);

            //重定向
            context.Response.Redirect("../News/NewsListHandler.ashx");

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.异步无刷新新闻列表分页
{
    /// <summary>
    /// GetNewsList 的摘要说明
    /// </summary>
    public class GetNewsList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            
            //获取页数据
            int pageIndex = int.Parse(context.Request["pageIndex"]??"1");
            int pageSize = int.Parse(context.Request["pageSize"] ?? "10");
            int totalListCount = 0;


            //获得传输的数据
            News.BLL.HKSJ_Main bllMain = new News.BLL.HKSJ_Main();
            var newsList= bllMain.MyGetListByPage(pageSize, pageIndex,out totalListCount);
            string navString = NavPager.ShowPageNavigate(pageSize, pageIndex, totalListCount);
            var responseData = new { newsList = newsList, NavString = navString };

            //返回
            System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(jsSerializer.Serialize(responseData));

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
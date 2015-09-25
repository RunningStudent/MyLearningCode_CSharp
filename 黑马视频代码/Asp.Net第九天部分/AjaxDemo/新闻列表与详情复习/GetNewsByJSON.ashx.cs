using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News.BLL;
using Maticsoft.Common;
namespace Demo.新闻列表与详情复习
{
    /// <summary>
    /// GetNewsByJSON 的摘要说明
    /// </summary>
    public class GetNewsByJSON : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //获取分页需要的数据
            int pageSize = int.Parse(context.Request["pageSize"] ?? "5");
            int pageIndex = int.Parse(context.Request["pageIndex"] ?? "1");
            int totalListCount = 0;
            HKSJ_Main bllmain = new HKSJ_Main();
            //根据需求获得指定位置的新闻
            List<News.Model.HKSJ_Main> dataList = bllmain.MyGetListByPage(pageSize, pageIndex, out totalListCount);
           
            //获得分页导航栏链接的HTML
            string navHtml = NavPager.ShowPageNavigate(pageSize, pageIndex, totalListCount);

            //封装成一个对象
            var responseData = new { dataList = dataList, navHtml = navHtml };

            System.Web.Script.Serialization.JavaScriptSerializer jsSer = new System.Web.Script.Serialization.JavaScriptSerializer();

            context.Response.Write(jsSer.Serialize(responseData));

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
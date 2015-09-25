using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News.BLL;
using News.Model;
namespace Demo.用AJax显示新闻列表
{
    /// <summary>
    /// GetNewsInJSON 的摘要说明
    /// </summary>
    public class GetNewsInJSON : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //获取数据
            News.BLL.HKSJ_Main bllMain = new News.BLL.HKSJ_Main();
            List<News.Model.HKSJ_Main> newslist = new List<News.Model.HKSJ_Main>();
            newslist = bllMain.GetModelList(string.Empty);

            //序列化
            System.Web.Script.Serialization.JavaScriptSerializer JsSer = new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(JsSer.Serialize(newslist));
            


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
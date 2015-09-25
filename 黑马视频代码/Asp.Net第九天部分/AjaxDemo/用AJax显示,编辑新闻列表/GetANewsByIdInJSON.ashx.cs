using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News.BLL;
namespace Demo.用AJax显示_编辑新闻列表
{
    /// <summary>
    /// GetANewsByIdInJSON 的摘要说明
    /// </summary>
    public class GetANewsByIdInJSON : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int id = int.Parse(context.Request["id"]??"0");
            HKSJ_Main bllMain = new HKSJ_Main();

            News.Model.HKSJ_Main modelMain = bllMain.GetModel(id);

            System.Web.Script.Serialization.JavaScriptSerializer JSser = new System.Web.Script.Serialization.JavaScriptSerializer();

            context.Response.Write(JSser.Serialize(modelMain));

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
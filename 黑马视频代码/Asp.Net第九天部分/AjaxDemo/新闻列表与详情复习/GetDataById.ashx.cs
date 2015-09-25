using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News.BLL;
namespace Demo.新闻列表与详情复习
{
    /// <summary>
    /// GetDataById 的摘要说明
    /// </summary>
    public class GetDataById : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int id = int.Parse(context.Request["id"] ?? "0");
            HKSJ_Main bllMain = new HKSJ_Main();
            News.Model.HKSJ_Main modelMain = bllMain.GetModel(id);

            System.Web.Script.Serialization.JavaScriptSerializer jsScriptSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            context.Response.Write(jsScriptSerializer.Serialize(modelMain));


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
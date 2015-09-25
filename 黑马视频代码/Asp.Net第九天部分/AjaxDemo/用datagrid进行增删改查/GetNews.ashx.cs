using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News.BLL;
namespace Demo.用datagrid进行增删改查
{
    /// <summary>
    /// GetNews 的摘要说明
    /// </summary>
    public class GetNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //获取请求数据
            int pageIndex = int.Parse(context.Request["page"]);
            int pageSize = int.Parse(context.Request["rows"]);
            int totalListCount=0;
            //获得返回数据
            HKSJ_Main bllMain = new HKSJ_Main();
            List<News.Model.HKSJ_Main>mainModelList=bllMain.MyGetListByPage(pageSize, pageIndex, out totalListCount);
            var responseData = new { total = totalListCount, rows = mainModelList };

            System.Web.Script.Serialization.JavaScriptSerializer jsSerialize = new System.Web.Script.Serialization.JavaScriptSerializer();

            context.Response.Write(jsSerialize.Serialize(responseData));
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
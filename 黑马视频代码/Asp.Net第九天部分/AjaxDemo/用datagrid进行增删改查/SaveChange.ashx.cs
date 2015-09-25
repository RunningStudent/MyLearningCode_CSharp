using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News.BLL;
namespace Demo.用datagrid进行增删改查
{
    /// <summary>
    /// SaveChange 的摘要说明
    /// </summary>
    public class SaveChange : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            HKSJ_Main bllMain=new HKSJ_Main();
            int id = int.Parse(context.Request["Id"]);
            News.Model.HKSJ_Main modelMain = bllMain.GetModel(id);
            modelMain.title = context.Request["txtTitle"];
            modelMain.type = context.Request["txtType"];

            bllMain.Update(modelMain);
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
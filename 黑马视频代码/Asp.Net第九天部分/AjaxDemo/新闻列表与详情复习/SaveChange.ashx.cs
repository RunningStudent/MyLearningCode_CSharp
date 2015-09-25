using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News.BLL;

namespace Demo.新闻列表与详情复习
{
    /// <summary>
    /// SaveChange 的摘要说明
    /// </summary>
    public class SaveChange : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            //我应该查询出来后在修改,毕竟不一定全修改
            News.Model.HKSJ_Main mainModel = new News.Model.HKSJ_Main();
            mainModel.ID = int.Parse(context.Request["ID"]);
            mainModel.people = context.Request["people"];
            mainModel.picUrl = "";
            mainModel.title = context.Request["title"]??"";
            mainModel.content = context.Request["content"];
            mainModel.Date = DateTime.Now;
            mainModel.type = "";

            HKSJ_Main bllMain = new HKSJ_Main();
            bllMain.Update(mainModel);
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
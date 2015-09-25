using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News;
using News.Model;
using System.IO;
namespace News.Web.News
{
    /// <summary>
    /// EditHandler 的摘要说明
    /// </summary>
    public class EditHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            //获得id
            int id;
            int.TryParse(context.Request["id"].ToString(),out id);
            BLL.Main mainBll = new BLL.Main();
            
            //展示数据
            if (context.Request["Action"]!="Edit")
            {
                string templePath = context.Request.MapPath("../Temple/EditTemple.htm");
                string result = File.ReadAllText(templePath);

                Main mainModle = mainBll.GetModel(id);
                result = result.Replace("@title", mainModle.title);
                result = result.Replace("@people", mainModle.people);
                result = result.Replace("@type", mainModle.type);
                result = result.Replace("@date", mainModle.Date.ToString());
                result = result.Replace("@id", id.ToString());

                context.Response.Write(result);
            }
                //保存数据到数据库,并跳转
            else
            {
                //代码生成器的方法是保存所有的数据
                //于是先查询出Model类,修改之,再保存
                Main mainModle=mainBll.GetModel(id);
                mainModle.ID = id;
                mainModle.type = context.Request["type"];
                mainModle.title = context.Request["title"];
                mainModle.people = context.Request["people"];
                mainModle.Date = DateTime.Parse(context.Request["date"]);
                mainBll.Update(mainModle);

                context.Response.Redirect("NewsListHandler.ashx");
            }



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
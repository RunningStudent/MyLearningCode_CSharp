using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using News;
using News.Model;
using System.Text;
using System.IO;
namespace News.Web.News
{
    /// <summary>
    /// NewsListHandler 的摘要说明
    /// </summary>
    public class NewsListHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            //获取数据,失败!!!Model中的Main与Bll中的Main重名
            BLL.Main mainBll = new BLL.Main();
            List<Main> modelList=mainBll.GetModelList(string.Empty);
            

            //拼接页面html
            StringBuilder sb = new StringBuilder();
            foreach (var item in modelList)
            {
                //<th>ID</th><th>标题</th><th>日期</th><th>创建人</th><th>操作</th>
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td><a href='DeleteHandler.ashx?id={0}'>删除</a>&nbsp;&nbsp;&nbsp;<a href='EditHandler.ashx?id={0}'>编辑</a></td></tr>", item.ID, item.title, item.Date, item.people);
            }

            //载入模板,生成html
            string templePath = context.Request.MapPath(@"../Temple/ListPageTemple.htm");
            string result = File.ReadAllText(templePath);
            result = result.Replace("@listTable", sb.ToString());

            
            context.Response.Write(result);

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
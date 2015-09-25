using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Web.MyCRUD
{
    public partial class AddNews : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                BLL.HKSJ_Main mainBll = new BLL.HKSJ_Main();
                Model.HKSJ_Main newsModel = new Model.HKSJ_Main();
                //获得新闻数据
                newsModel.title = Context.Request["title"];
                newsModel.picUrl = "";
                newsModel.people = "";
                newsModel.Date = DateTime.Now;
                newsModel.type = "";
                newsModel.content = Context.Request["content"];
                //保存到数据库
                mainBll.Add(newsModel);
                //重定向
                Context.Response.Redirect("ShowListForm.aspx");
            }
            
        }
    }
}
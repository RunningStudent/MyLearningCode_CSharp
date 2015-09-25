using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.使用服务器控件对新闻的增删改查
{
    public partial class NewsShow : System.Web.UI.Page
    {


        private News.BLL.HKSJ_Main bllMain = new News.BLL.HKSJ_Main();

        protected void Page_Load(object sender, EventArgs e)
        {
            int pageIndex = int.Parse(Request["pageIndex"]??"1");
            int pageSize = int.Parse(Request["pageSize"]??"10");
            int totalListCount = 0;
            if (!IsPostBack)
            {
                //页面加载的时候设置数据源
                this.Repeater1.DataSource = bllMain.MyGetListByPage(pageSize,pageIndex,out totalListCount);
                this.Repeater1.DataBind();
            }
            this.NavString.Text = NavPager.ShowPageNavigate(pageSize, pageIndex, totalListCount);
        }
        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="Delete")
            {
                int deleteNewsID = int.Parse(e.CommandArgument.ToString());
               
                bllMain.Delete(deleteNewsID);
                //数据重新绑定
                Repeater1.DataBind();
                //发现绑完后自动刷新页面但是这个页面没有东西,所以我再刷新一次本页面
                Response.Redirect(Request.Url.ToString());
                return;
            }
            if (e.CommandName=="Edit")
            {
                int editID = int.Parse(e.CommandArgument.ToString());
                Response.Redirect("EditNews.aspx?id=" + editID);
                return;
            }
        }

        protected void btnAddNews_Click(object sender, EventArgs e)
        {
            //点击添加新闻按钮,跳转页面
            Response.Redirect("AddNews.aspx");
        }
    }
}
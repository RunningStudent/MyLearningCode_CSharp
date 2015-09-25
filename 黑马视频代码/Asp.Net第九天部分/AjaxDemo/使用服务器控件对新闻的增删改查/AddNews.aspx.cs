using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.使用服务器控件对新闻的增删改查
{
    public partial class AddNews : System.Web.UI.Page
    {

        News.BLL.HKSJ_Main bllMain = new News.BLL.HKSJ_Main();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNews_Click(object sender, EventArgs e)
        {
            //数据获取
            News.Model.HKSJ_Main modelMain = new News.Model.HKSJ_Main();
            modelMain.people = this.txtPeople.Text;
            modelMain.title = this.txtTitle.Text;
            modelMain.picUrl = "";
            modelMain.type = "";
            modelMain.content = this.txtBoxContent.Text;
            modelMain.Date = DateTime.Now;

            //添加
            bllMain.Add(modelMain);
            Response.Redirect("NewsShow.aspx");
        }
    }
}
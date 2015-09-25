using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.使用服务器控件对新闻的增删改查
{
    public partial class EditNews : System.Web.UI.Page
    {
        News.BLL.HKSJ_Main bllMain = new News.BLL.HKSJ_Main();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id=int.Parse(Request["id"]);
            News.Model.HKSJ_Main modelMain = bllMain.GetModel(id);
            this.txtTitle.Text = modelMain.title;
            this.txtPeople.Text = modelMain.people;
            this.txtBoxContent.Text = modelMain.content;
        }
    }
}
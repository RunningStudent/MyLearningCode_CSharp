using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.使用服务器控件对新闻的增删改查
{
    public partial class Detail : System.Web.UI.Page
    {

        News.BLL.HKSJ_Main bllMain = new News.BLL.HKSJ_Main();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request["id"]);
            News.Model.HKSJ_Main modelMain=bllMain.GetModel(id);
            this.lbID.Text = modelMain.ID.ToString();
            this.ltPeople.Text = modelMain.people;
            //UBB转HTML,再输出
            this.ltContent.Text=Ubb2Html.Decode(modelMain.content);

        }
    }
}
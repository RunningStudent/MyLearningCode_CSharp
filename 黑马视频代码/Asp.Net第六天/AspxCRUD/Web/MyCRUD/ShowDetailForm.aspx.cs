using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Web.MyCRUD
{
    public partial class ShowDetailForm : System.Web.UI.Page
    {

        public Model.HKSJ_Main NewsDeatail { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Context.Request["id"]??"0");
            BLL.HKSJ_Main mainBll = new BLL.HKSJ_Main();
            NewsDeatail=mainBll.GetModel(id);

        }
    }
}
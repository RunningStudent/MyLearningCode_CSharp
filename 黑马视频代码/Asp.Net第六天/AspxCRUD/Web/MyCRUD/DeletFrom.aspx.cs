using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Web.MyCRUD
{
    public partial class DeletFrom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Context.Request["id"]);
            new BLL.HKSJ_Main().Delete(id);
            Context.Response.Redirect("AdmitShowList.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Web.黑马7Demo
{
    public partial class SessionDemo : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //第一次请求
                //下面就是一个Session对象
                Session["Key"] = DateTime.Now;

            }
            else
            {
                //第二次请求
                //这里Session["Key"]已经被赋值了
                Response.Write(Session["Key"]);
            }
        }
    }
}
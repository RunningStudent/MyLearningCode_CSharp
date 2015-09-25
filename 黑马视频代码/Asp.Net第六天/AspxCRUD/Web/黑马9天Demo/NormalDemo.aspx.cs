using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace News.Web.黑马9天Demo
{
    public partial class NormalDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("输出当前执行页面后置类路径" + Assembly.GetExecutingAssembly().Location);
            this.Literal1.Text = "<h1>这是一个控件,能把字符串原封不动的显示在页面中</h1>";
        }
    }
}
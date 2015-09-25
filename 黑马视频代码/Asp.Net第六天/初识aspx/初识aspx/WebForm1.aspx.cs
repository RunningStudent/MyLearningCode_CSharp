using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 初识aspx
{
    //代码后缀类,相当于一般处理程序
    public partial class WebForm1 : System.Web.UI.Page
    {


        public string TestPrototype { get; set; }


        /// <summary>
        /// 页面完全加载完成后,做的事
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.TestPrototype = "我是类成员";
        }
    }
}
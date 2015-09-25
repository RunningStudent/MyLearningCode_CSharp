using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Web.黑马7Demo
{
    public partial class ViewStateDemo : System.Web.UI.Page
    {

        public int Num { get; set; }
        public string txtValue { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            //页面利用ViewState自增Demo,判断文本框是否改变了
            if (IsPostBack)
            {
                //第二次访问页面
                Num = (int)ViewState["Num"] + 1;
                ViewState["Num"] = Num;            


                string hideTxt= ViewState["HideTxt"].ToString().Trim();
                string txt=Context.Request["TxtValue"].Trim();
                //判断是否改变了
                if (hideTxt != txt)
                {
                    Context.Response.Write("<br>文本以改变");
                    //改变了要保存起来

                    txtValue = Context.Request["txtValue"];
                    ViewState["HideTxt"] = Context.Request["TxtValue"];
                }
                else
                {
                    //由于是无状态的所以每次访问txtValue是空的
                    //所以要重新赋值   
                    txtValue = Context.Request["txtValue"].Trim();
                   
                }
                
                
            }
            else
            {
                
                //第一次访问页面
                ViewState["Num"] = Num = 1;

                //把这次的文本框内容保存起来
                ViewState["HideTxt"] = Context.Request["TxtValue"]??" ";
                //保存到属性中,为了在页面中显示
                txtValue = Context.Request["TxtValue"];

            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.Web.黑马7Demo
{
    //封装一些每个页面都会用到的操作
    public class BasePage : System.Web.UI.Page
    {

        public Model.HKSJ_USERS UserInfo { get; set; }

        /// <summary>
        /// 特定写法!!!页面初始化时候干的事,这个代码会在编译时与管道事件绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void Page_Init(object sender, EventArgs e)
        {
            #region 判断是否登入

            if(Session["UserInfo"]!=null)
            {
                Model.HKSJ_USERS UserInfo = Session["UserInfo"] as Model.HKSJ_USERS;
                Response.Redirect("../MyCRUD/AdminForm.aspx");
            }

            #endregion
        }
    }
}
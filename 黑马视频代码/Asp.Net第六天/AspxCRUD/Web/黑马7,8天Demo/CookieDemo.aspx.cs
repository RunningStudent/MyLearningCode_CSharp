using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Web.黑马7Demo
{
    public partial class CookieDemo : BasePage
    {

        /// <summary>
        /// 显示在页面表单的用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 用于提示信息的脚本代码
        /// </summary>
        public string ScriptString { get; set; }

        //登入后保存用户名,第二次自动显示
        protected void Page_Load(object sender, EventArgs e)
        {
            //第一次访问是地址栏访问
            //第二次是表单提交访问,即下面的if

            //如果是表单提交
            if (IsPostBack)
            {
                //能到这里说明,是第二次访问,而不是第三第四次,因为如果已经登入在Page_Init处理过了

                string userName = Context.Request["account"];
                string passWord=Context.Request["pwd"];

                #region 处理Cookie
                //把用户名保存到Cookie
                
                //解决中文乱码
                Context.Response.Cookies["UserName"].Value = Server.UrlDecode(userName);
                //设置生命周期
                Context.Response.Cookies["UserName"].Expires = DateTime.Now.AddSeconds(10);
                UserName = userName;
                #endregion

                #region 校验验证码
                string validateCode = Request["captcha"];
                //如果验证码错误
                if (validateCode != Session["Validate"].ToString())
                {
                    ScriptString = @"<script type=""text/javascript"">alert('验证码错误')</script>";
                    //不能写Response.End(),否则什么都不会显示到页面上
                    return;
                }
                #endregion

                #region 校验用户名密码
                BLL.HKSJ_USERS userBll = new BLL.HKSJ_USERS();

                string strwhere = "LoginName='" + userName + "' and PassWord='" + passWord+"'";
                List<Model.HKSJ_USERS> userModeList=userBll.GetModelList(strwhere);

                //如果找不到用户名密码
                if (userModeList.Count<=0)
                {
                    ScriptString=@"<script type=""text/javascript"">alert('用户名密码错误')</script>";
                    return;
                }
                
                #endregion

                #region 登入成功后,写入Session,其目的是为了不让所有人都能访问第二个页面
                Session["UserInfo"] = userModeList.First();
                #endregion


                //跳转
                Response.Redirect("../MyCRUD/AdminForm.aspx");
            }
            else
            {
                //如果是页面跳转!!,注意是页面跳转,不只是第一次访问
                //拿到Cookie中的用户名,保存到私有字段
                UserName = Server.UrlDecode(Request["UserName"] ?? "");//这种方式能拿到Cookie
            }
        }
    }
}
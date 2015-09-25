using System;
using System.Web;
using System.Collections;
using System.ComponentModel;
using System.Web.SessionState;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.Security;
using LTP.Accounts.Bus;
namespace News.Web
{
    /// <summary>
    /// Global 的摘要说明。
    /// </summary>
    public class Global : System.Web.HttpApplication
    {


        public Global()
        {

        }


        //整个网站周期内只被调用一次
        protected void Application_Start(Object sender, EventArgs e)
        {
            //初始化在线人数为0
            Application["OnlineNum"] = 0;
        }

        private static readonly object OnlineNumLock = new object();


        //会话开始
        protected void Session_Start(Object sender, EventArgs e)
        {

            //防止同时访问,加个锁
            //也可以用字符串常量代表锁
            lock (OnlineNumLock)
            {
                int num = int.Parse(Application["OnlineNum"].ToString());
                Application["OnlineNum"] = num + 1; 
            }
        }





        //管道事件注册方式,编写像下面的代码Application_事件名,编译时候会自动与相关的事件绑定

        //管道中的第一个事件
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
        }

        //网站凡是异常就触发该事假
        protected void Application_Error(Object sender, EventArgs e)
        {

        }

        //会话结束
        //这里实际上有延迟的,因为不知道用户是否打开网页后就直接关闭浏览器,或挂在那边
        //所以无法判断什么时候会话结束
        protected void Session_End(Object sender, EventArgs e)
        {

        }
        protected void Application_End(Object sender, EventArgs e)
        {
        }


    }
}


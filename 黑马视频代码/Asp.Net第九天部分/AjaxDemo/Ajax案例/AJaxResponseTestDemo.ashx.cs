using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo
{
    /// <summary>
    /// AJaxResponseTestDemo 的摘要说明
    /// </summary>
    public class AJaxResponseTestDemo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string username = context.Request["username"];
            string psw = context.Request["psw"];
            if (username==psw)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("Error");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
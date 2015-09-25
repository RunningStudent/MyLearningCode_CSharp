using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo
{
    /// <summary>
    /// ReturnTime 的摘要说明
    /// </summary>
    public class ReturnTime : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request["JSON"]!=null)
            {
                context.Response.Write("{\"Date\":\""+DateTime.Now.ToString()+"\"}");
                return;
            }

            context.Response.Write(DateTime.Now.ToString());
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
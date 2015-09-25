using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.用AJax显示_编辑新闻列表
{
    /// <summary>
    /// ChangeNews 的摘要说明
    /// </summary>
    public class ChangeNews : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            
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
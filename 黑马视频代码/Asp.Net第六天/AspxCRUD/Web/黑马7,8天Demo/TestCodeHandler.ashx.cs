using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;
using System.Web.SessionState;

namespace News.Web.黑马7Demo
{



    /// <summary>
    /// TestCodeHandler 的摘要说明
    /// </summary>
    public class TestCodeHandler : IHttpHandler,IRequiresSessionState//一般处理程序必须写这个标记接口才能访问Session
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "img/plain";
            //写入验证码
            Maticsoft.Common.ValidateCode code = new Maticsoft.Common.ValidateCode();
            string validateCode = code.CreateValidateCode(4);
            code.CreateValidateGraphic(validateCode, context);

            //把验证码写入Session
            context.Session["Validate"] = validateCode;

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
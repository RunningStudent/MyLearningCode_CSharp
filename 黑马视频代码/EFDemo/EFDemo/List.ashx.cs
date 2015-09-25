using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFBLL;
using EFModel;
namespace EFDemo
{
    /// <summary>
    /// List 的摘要说明
    /// </summary>
    public class List : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            MyClassBLL bll = new MyClassBLL();
            List<MyClass> list = bll.WhereAll();
            
            var newList = from e in list
                          select new { id = e.classId, name = e.className };
            AjaxObj obj = new AjaxObj()
            {
                msg = "",
                status = "1",
                datas = newList
            };
            context.Response.Write(JSONHelper.ToJSONString(obj));
            
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
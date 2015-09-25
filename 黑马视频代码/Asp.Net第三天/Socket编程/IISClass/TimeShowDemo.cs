using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketProgram.IISClass
{
    public class TimeShowDemo:IHttpProcess
    {

        public void ProcessRequest(HttpContext context)
        {
            //这里并未设置contextType,而是使用了默认的text格式
            context.Response.ResponseBody = 
                Encoding.UTF8.GetBytes(string.Format("<html><body><h3>{0}</h3></body></ html>",DateTime.Now.ToString()));
            context.Response.ResponseStatus = 200;
            
        }
    }
}

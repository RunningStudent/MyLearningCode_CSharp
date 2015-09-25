using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketProgram.IISClass
{
    public class HttpContext
    {
        public HttpResponse Response { get; set; }
        public HttpRequest Request { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="receiveStr"></param>
        public HttpContext(string receiveStr)
        {
            Request = new HttpRequest(receiveStr);
            Response = new HttpResponse(Request);
        }
    }
}

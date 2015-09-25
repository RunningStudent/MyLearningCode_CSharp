using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SocketProgram.IISClass
{
    public class HttpResponse
    {
        /// <summary>
        /// 响应报文体
        /// </summary>
        public byte[] ResponseBody { get; set; }

        /// <summary>
        /// 请求报文类
        /// </summary>
        public HttpRequest Request { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="request"></param>
        public HttpResponse(HttpRequest request)
        {
            Request = request;

            //初始化状态码键值对
            ResponseStatusDictionnary.Add(200, "OK");
            ResponseStatusDictionnary.Add(404, "Not Found");
        }

        /// <summary>
        /// 状态码键值对
        /// </summary>
        public Dictionary<int, string> ResponseStatusDictionnary = new Dictionary<int, string>();

        /// <summary>
        /// 状态码
        /// </summary>
        public int ResponseStatus { get; set; }


        /// <summary>
        /// 获得响应报文头
        /// </summary>
        /// <param name="status">状态码</param>
        /// <returns>字节流</returns>
        public byte[] GetResponseHead()
        {

            string str = string.Format("HTTP/1.1 {0} {1}\r\nCache-Control: private\r\nContent-Type: {2}\r\nServer: Microsoft-IIS/8.0\r\nX-Powered-By: ASP.NET\r\nDate: Fri, 06 Sep 2013 06:49:41 GMT\r\nContent-Length: {3}\r\n\r\n",/*注意左边要有两个回车换行符*/ ResponseStatus, ResponseStatusDictionnary[ResponseStatus], this.GetContentType(), this.GetResponseBodyLenth());
            return Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// 获取响应报文长度
        /// </summary>
        /// <returns></returns>
        private int GetResponseBodyLenth()
        {
            return ResponseBody.Length;
        }

        /// <summary>
        /// 根据文件后缀,返回对应的contentType
        /// </summary>
        /// <returns></returns>
        public string GetContentType()
        {
            string ext = Path.GetExtension(this.Request.Url);
            string text = ext;
            string type;
            switch (text)
            {
                case ".aspx":
                case ".html":
                case ".htm":
                    type = "text/html; charset=UTF-8";
                    return type;
                case ".png":
                    type = "image/png";
                    return type;
                case ".gif":
                    type = "image/gif";
                    return type;
                case ".jpg":
                case ".jpeg":
                    type = "image/jpeg";
                    return type;
                case ".css":
                    type = "text/css";
                    return type;
                case ".js":
                    type = "application/x-javascript";
                    return type;
            }
            type = "text/plain; charset=gbk";
            return type;
        }


    }
}

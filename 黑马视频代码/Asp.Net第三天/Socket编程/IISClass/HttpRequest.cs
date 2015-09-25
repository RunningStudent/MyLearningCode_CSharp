using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketProgram.IISClass
{
    public  class HttpRequest
    {
        public string HttpMethod { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }

        /// <summary>
        /// 解析http请求报文
        /// </summary>
        /// <param name="receiveStr">http请求报文</param>
        public HttpRequest(string receiveStr)
        {
            //获取协议第一行
            string firstLine = receiveStr.Replace("\r\n", "\r").Split('\r')[0];

            HttpMethod = firstLine.Split(new char[] { ' ' })[0];
            Url = firstLine.Split(new char[] { ' ' })[1];
            Version = firstLine.Split(new char[] { ' ' })[2];
        }
    }
}

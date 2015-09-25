using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;

namespace SocketProgram.IISClass
{
    public class ProcessDemo1:IHttpProcess
    {
        
        /// <summary>
        /// 处理http上下文
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            //获得文件扩展名
            string ex = Path.GetExtension(context.Request.Url);
            //获得exe文件的位置 
            string binPath = AppDomain.CurrentDomain.BaseDirectory;
            //http报文url范例:/FirstWeb/FirstShower.ashx
            string filePath=Path.Combine(binPath,context.Request.Url.TrimStart(new char[]{'/'}));

            //处理动态页面
            if (ex==".aspx")
            {
                string className=Path.GetFileNameWithoutExtension(filePath);
                //加载当前项目程序集,因为整个项目的代码都在exe文件中,从该exe中反射出类,并实例化,调用接口方法
                IHttpProcess demo = 
                    Assembly.Load("SocketProgram").CreateInstance("SocketProgram.IISClass." + className) as IHttpProcess;
                demo.ProcessRequest(context);
                return;
            }


            //处理静态页面
            //如果文件存在
            if (File.Exists(filePath))
            {
                byte[] bodyByte=File.ReadAllBytes(filePath);
                context.Response.ResponseBody = bodyByte;
                context.Response.ResponseStatus = 200;
            }
            else//如果没有找到文件返回错误页面
            {
                //把要访问的页面改成错误页面的Url,保证获取到正确的ContextType
                context.Request.Url = "/WebSite/404.htm";
                string errorPagePath = Path.Combine(binPath, "WebSite\\404.htm");
                byte[] errorBodyByte = File.ReadAllBytes(errorPagePath);
                context.Response.ResponseBody = errorBodyByte;
                context.Response.ResponseStatus = 404;
            }

        }
    }
}

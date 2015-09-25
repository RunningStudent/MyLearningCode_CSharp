<%@ WebHandler Language="C#" Class="DemoHandler" %>

using System;
using System.Web;

public class DemoHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        ////输出普通文本
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("输出普通文本!");
        //context.Response.Write("Hello World");

        ////输出HTML
        //context.Response.ContentType = "text/html";
        //context.Response.Write("<br><em>输出Html</em>");
        //context.Response.Write("<br><font size='7' color='red'>Hello World</font>");

        //输出文件,图片
        context.Response.ContentType = "image/bmp";
        context.Response.WriteFile("汉诺塔未完成.bmp");
   

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
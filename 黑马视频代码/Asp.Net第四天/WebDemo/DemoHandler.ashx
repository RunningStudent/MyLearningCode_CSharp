<%@ WebHandler Language="C#" Class="DemoHandler" %>

using System;
using System.Web;

public class DemoHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        ////�����ͨ�ı�
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("�����ͨ�ı�!");
        //context.Response.Write("Hello World");

        ////���HTML
        //context.Response.ContentType = "text/html";
        //context.Response.Write("<br><em>���Html</em>");
        //context.Response.Write("<br><font size='7' color='red'>Hello World</font>");

        //����ļ�,ͼƬ
        context.Response.ContentType = "image/bmp";
        context.Response.WriteFile("��ŵ��δ���.bmp");
   

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
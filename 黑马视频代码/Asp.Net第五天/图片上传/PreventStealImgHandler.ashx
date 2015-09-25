<%@ WebHandler Language="C#" Class="PreventStealImgHandler" %>

using System;
using System.Web;
using System.Security.Policy;
public class PreventStealImgHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        //注意这里修改了返回数据的样式
        context.Response.ContentType = "imge/bmp";

        //获取访问者的Uri
        Uri reference = context.Request.UrlReferrer;
        
        //获取要访问的地方的Uri
        Uri current = context.Request.Url;
        
        //对比两个Uri是否是同一个服务器端口
        //如果是则正常返回图片
        //后面两个参数作用未知
        if (Uri.Compare(reference,current, UriComponents.HostAndPort, UriFormat.SafeUnescaped, StringComparison.CurrentCulture)==0)
        {
            context.Response.WriteFile("UpLoadFiles/a.bmp");
        }
        else
        {
            context.Response.WriteFile("UpLoadFiles/small_6eca37cd-8ff9-434b-9bbf-572d35209a72Asp.Net原理第一版.bmp");
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
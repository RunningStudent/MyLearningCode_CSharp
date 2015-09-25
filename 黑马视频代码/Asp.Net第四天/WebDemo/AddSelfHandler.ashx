<%@ WebHandler Language="C#" Class="AddSelfHandler" %>

using System;
using System.Web;
using System.IO;
public class AddSelfHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";

        int number;
        if (context.Request["digical"] == null || !int.TryParse(context.Request["digical"],out number))//尝试装换转换成功,那么剩下只要++
        {
            number = 0;
        }
        else
        {
            number++;
        }
            

        string pagePath = context.Request.MapPath("AddSelftPage.htm");
        string result = File.ReadAllText(pagePath);
        result=result.Replace("@d", number.ToString());

        context.Response.Write(result);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
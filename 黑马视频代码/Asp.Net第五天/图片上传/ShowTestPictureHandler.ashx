<%@ WebHandler Language="C#" Class="ShowTestPictureHandler" %>

using System;
using System.Web;
public class ShowTestPictureHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        ValidateCode val = new ValidateCode();
        val.CreateValidateGraphic("1234561", context);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
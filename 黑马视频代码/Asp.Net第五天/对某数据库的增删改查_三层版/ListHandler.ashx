<%@ WebHandler Language="C#" Class="ListHandler" %>

using System;
using System.Web;
using BLL;
using System.Collections.Generic;
using Model;
using System.Text;
using System.IO;
public class ListHandler : IHttpHandler {

    private MainBLL mainBLL = new MainBLL();
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        
        List<TblMain> list=mainBLL.GetAllNews();

        StringBuilder sb = new StringBuilder();
        //ID, title, content, type, Date, people, picUrl
        foreach (var item in list)
        {
            sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>",
                item.ID,item.Title,item.Type,item.Date,item.People,item.Url); 
        }

        string tempPath = context.Request.MapPath("MainTableTemp.htm");
        string result = File.ReadAllText(tempPath);
        result = result.Replace("@showTable", sb.ToString());
        context.Response.Write(result);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
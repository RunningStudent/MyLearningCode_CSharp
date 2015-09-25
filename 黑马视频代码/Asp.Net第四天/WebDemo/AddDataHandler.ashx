<%@ WebHandler Language="C#" Class="AddDataHandler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
public class AddDataHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        //context.Request[]等效于context.Request.Form[]context.Request.QueryString[],具体看其源代码
        string title = context.Request["Title"];
        string qunNum = context.Request["QunNum"];

        //添加数据
        string sqlstr = "insert into QunList81(QunNum,Title) values(@QunNum,@title)";
        string constr = ConfigurationManager.ConnectionStrings["qqDB"].ConnectionString;
        using (SqlConnection connect=new SqlConnection(constr))
        {
            connect.Open();
            using (SqlCommand com=new SqlCommand(sqlstr,connect))
            {
                com.Parameters.Add(new SqlParameter("@QunNum", qunNum));
                com.Parameters.Add(new SqlParameter("@title", title));
                com.ExecuteNonQuery();
            }
        }

        
        //重定向位置
        context.Response.Redirect("ListDBToTableHandler.ashx");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
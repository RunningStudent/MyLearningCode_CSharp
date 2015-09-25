<%@ WebHandler Language="C#" Class="DeleteHandler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
public class DeleteHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";
        int id = int.Parse(context.Request["id"]);
        
        string sqlstr = "delete QunList81 where Id=@id";
        string constr = ConfigurationManager.ConnectionStrings["qqDB"].ConnectionString;
        using (SqlConnection connect=new SqlConnection(constr))
        {
            connect.Open();
            using (SqlCommand com=new SqlCommand(sqlstr,connect))
            {
                com.Parameters.Add(new SqlParameter("id", id));
                if(com.ExecuteNonQuery()>0)
                {
                    context.Response.Redirect("ListDBToTableHandler.ashx");
                }
                else
                {
                    context.Response.Write("删除失败");
                }
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
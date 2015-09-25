<%@ WebHandler Language="C#" Class="ShowDetailHandler" %>

using System;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
public class ShowDetailHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";

        //获得被查询列的Id
        int id = int.Parse(context.Request["id"]);
        
        StringBuilder sb = new StringBuilder();
        
        string sqlstr = "select Id, QunNum, MastQQ, CreateDate, Title, Class, QunText from QunList81 where Id=@id";
        string connstr = ConfigurationManager.ConnectionStrings["qqDB"].ConnectionString;
        
        using (SqlDataAdapter ad=new SqlDataAdapter(sqlstr,connstr))
        {
            //加入参数
            ad.SelectCommand.Parameters.Add("@id", id);
            //填充表格
            DataTable dt = new DataTable();
            ad.Fill(dt);
            
            //生成html代码
            sb.AppendFormat("<tr><td>Id</td><td>{0}</td></tr>", dt.Rows[0]["Id"]);
            sb.AppendFormat("<tr><td>QunNum</td><td>{0}</td></tr>", dt.Rows[0]["QunNum"]);
            sb.AppendFormat("<tr><td>MastQQ</td><td>{0}</td></tr>", dt.Rows[0]["MastQQ"]);
            sb.AppendFormat("<tr><td>CreateDate</td><td>{0}</td></tr>", dt.Rows[0]["CreateDate"]);
            sb.AppendFormat("<tr><td>Title</td><td>{0}</td></tr>", dt.Rows[0]["Title"]);
            sb.AppendFormat("<tr><td>Class</td><td>{0}</td></tr>", dt.Rows[0]["Class"]);
            sb.AppendFormat("<tr><td>QunText</td><td>{0}</td></tr>", dt.Rows[0]["QunText"]);
        }


        //载入模板
        string tempPagePath = context.Request.MapPath("TemplePage.htm");
        string tempStr = System.IO.File.ReadAllText(tempPagePath);
        //填充模板
        string rusult=tempStr.Replace("@tableMsg", sb.ToString());
        context.Response.Write(rusult);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
<%@ WebHandler Language="C#" Class="EditHandler" %>

using System;
using System.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
public class EditHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/html";


        string connstr = ConfigurationManager.ConnectionStrings["qqDB"].ConnectionString;
        //接受数据保存到数据库时候
        if (context.Request["Action"]=="Edit")
        {
            //获取数据
            string id = context.Request["Idtext"];
            string QunNum = context.Request["QunNumtext"];
            string MastQQ = context.Request["MastQQtext"];

            string sqlstr = "update QunList81 set QunNum=@qunNum,MastQQ=@mastQQ where Id=@id";
            using (SqlConnection con=new SqlConnection(connstr))
            {
                SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@qunNum",QunNum),
                    new SqlParameter("@mastQQ",MastQQ),
                    new SqlParameter("@id",id),
                };
                
                con.Open();
                using (SqlCommand command=new SqlCommand(sqlstr,con))
                {
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
            //重定向位置
            context.Response.Redirect("ListDBToTableHandler.ashx");
            return;
        }
            //展示数据
        else
        {
            //获得被查询列的Id
            int id = int.Parse(context.Request["id"]);
            string sqlstr = "select Id, QunNum, MastQQ, CreateDate, Title, Class, QunText from QunList81 where Id=@id";
            
            DataTable dt = new DataTable();
            using (SqlDataAdapter ad = new SqlDataAdapter(sqlstr, connstr))
            {
                //加入参数
                ad.SelectCommand.Parameters.Add("@id", id);
                //填充表格
                ad.Fill(dt);
            }

            //载入模板
            string EditTemplepath = context.Request.MapPath("EditPage.htm");
            //填充数据
            string result = File.ReadAllText(EditTemplepath);
            result=result.Replace("@Id", dt.Rows[0]["Id"].ToString());
            result = result.Replace("@QunNum", dt.Rows[0]["QunNum"].ToString());
            result = result.Replace("@MastQQ", dt.Rows[0]["MastQQ"].ToString());

            //展示页面
            context.Response.Write(result);
            return;
        }
        
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}
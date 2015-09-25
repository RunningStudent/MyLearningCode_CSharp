<%@ WebHandler Language="C#" Class="ListDBToTableHandler" %>

using System;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
public class ListDBToTableHandler : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/html";

        StringBuilder sb = new StringBuilder();
        sb.Append("<html><head></head><body>");//标签要对称

        string connectString = ConfigurationManager.ConnectionStrings["qqDB"].ConnectionString;
        string sqlStr = "select  Id, Title, QunText  from QunList81";

        sb.AppendLine("</br><a href='AddPage.htm'>添加</a></br><table>");
        sb.AppendLine("<tr><th>Id</th><th>Title</th><th>QunText</th><th>Detail</th><th></th><th></th></tr>");
        //获取数据填充在一个表格中
        using (SqlConnection con = new SqlConnection(connectString))
        {
            con.Open();
            using (SqlCommand command = new SqlCommand(sqlStr, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            //在每个表格后边添加查看详细信息的链接,把Id传递到指定的一般处理程序
                            sb.AppendFormat(@"<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>
                                                <a href='ShowDetailHandler.ashx?id={0}'>详细信息</a>&nbsp;&nbsp;
                                                </td><td><a onclick=""return confirm('是否确定删除')"" href='DeleteHandler.ashx?id={0}'>删除</a></td>
                                                     <td><a href='EditHandler.ashx?id={0}'>编辑</a></td>
                                                </tr>",
                                    reader.GetInt32(0),
                                    reader["Title"],
                                    reader["QunText"]
                                );
                        }
                    }
                }    
            }
        }
        sb.AppendLine("</table>");
        sb.Append("</body></html>");
        context.Response.Write(sb.ToString());

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
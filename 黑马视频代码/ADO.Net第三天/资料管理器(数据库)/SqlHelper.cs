using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
namespace 资料管理器_数据库_
{
    static class SqlHelper
    {
        public static readonly string constr=ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection sc = new SqlConnection(constr))
            {
                using (SqlCommand command=new SqlCommand(sql,sc))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    sc.Open();
                    return command.ExecuteNonQuery();
                    
                }
            }
        }

        public static object ExecuteScalar(string sql,params SqlParameter[] parameters)
        {
            using (SqlConnection sc=new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand(sql, sc))
                {
                    if (parameters!=null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    sc.Open();
                    return command.ExecuteScalar();   
                }
            }
        }

        public static SqlDataReader ExecuteSqlDataReader(string sql, params SqlParameter[] parameters)
        {
            SqlConnection sc = new SqlConnection(constr);
            using (SqlCommand command = new SqlCommand(sql, sc))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                try
                {
                    sc.Open();
                    return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                }
                catch
                {
                    sc.Close();
                    throw;
                }
            }
        }

    }
}

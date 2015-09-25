using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace 使用sqlhelper对newtable进行增删改查
{
    //ExecuteDataTable(string sql,params SqlParameter[] parameters)、
    //ExecuteNonQuery(string sql,params SqlParameter[] parameters)、
    //ExecuteScalar(string sql,params SqlParameter[] parameters)等方法。
    public static class SqlHelper
    {
        private static readonly string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;


        public static int ExcuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection sc = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand(sql, sc))
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

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection sc = new SqlConnection(constr))
            {
                using (SqlCommand command = new SqlCommand(sql, sc))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    sc.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        public static SqlDataReader ExecuteDateReader(string sql, params SqlParameter[] parameters)
        {
            //不能using Connection,这样在没return 前Connection就被销毁了
            SqlConnection sc = new SqlConnection(constr);
            using (SqlCommand command = new SqlCommand(sql, sc))
            {
                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                sc.Open();
                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
        }
         
    }
}

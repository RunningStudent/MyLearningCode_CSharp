using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace 使用MD5的窗体登入
{
    static class SqlHelper
    {
        private static readonly string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        /// <summary>
        /// 增,删,改,返回影响数据的条数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="pars"></param>
        /// <returns>所影响的数据长度</returns>
        public static int ExecuteNonQuery(string sql, CommandType cmdType, params SqlParameter[] pars)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = cmdType;
                    if (pars != null)
                    {
                        com.Parameters.AddRange(pars);
                    }
                    con.Open();
                    return com.ExecuteNonQuery();

                }
            }
        }

        /// <summary>
        /// 数据查询,返回DataReader
        /// </summary>
        /// <param name="Sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string Sql, CommandType cmdType, params SqlParameter[] pars)
        {
            //不要using,否则Reader无效
            SqlConnection con = new SqlConnection(constr);
            using (SqlCommand com = new SqlCommand(Sql, con))
            {
                com.CommandType = cmdType;
                if (pars != null)
                {
                    com.Parameters.AddRange(pars);
                }
                //异常处理
                try
                {
                    con.Open();
                    //设置当rader销毁时候也跟着销毁
                    return com.ExecuteReader(CommandBehavior.CloseConnection);

                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }


        /// <summary>
        /// 返回一条数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="cmdType"></param>
        /// <param name="pars"></param>
        /// <returns>object类型数据</returns>
        public static object ExecuteScalar(string sql, CommandType cmdType, params SqlParameter[] pars)
        {
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.CommandType = cmdType;
                    if (pars != null)
                    {
                        com.Parameters.AddRange(pars);
                    }
                    con.Open();
                    return com.ExecuteScalar();

                }
            }
        }
        /// <summary>
        /// 返回DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="comdType"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public static DataTable ExecuteDataTable(string sql, CommandType comdType, params SqlParameter[] pars)
        {
            DataTable table = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, constr))
            {
                adapter.SelectCommand.CommandType = comdType;
                if (pars != null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pars);
                }
                adapter.Fill(table);
            }
            return table;
        }


    }
}

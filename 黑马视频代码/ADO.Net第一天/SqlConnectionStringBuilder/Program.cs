using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SqlConnectionStringBuilder类
{
    class Program
    {
        //SqlConnectionStringBuilder使用案例
        static void Main(string[] args)
        {
            //设置连接字符串属性
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "Y-4988160916C94";
            scsb.InitialCatalog = "ItCastCn";
            scsb.IntegratedSecurity = true;
            //生成连接字符串
            string constr = scsb.ConnectionString;

            Console.WriteLine(constr);
            using (SqlConnection sc = new SqlConnection(scsb.ConnectionString))
            {
                //添加连接状态改变事件
                sc.StateChange += new System.Data.StateChangeEventHandler(sc_StateChange);
                sc.Open();
              
            }
            Console.ReadKey();
        }

        //展示数据库连接状态
        static void sc_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            Console.WriteLine(e.CurrentState);
        }
    }
}

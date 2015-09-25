using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace StatementCompleted事件
{
    class Program
    {
        static void Main(string[] args)
        {
            string constr = "Data Source=Y-4988160916C94;Initial Catalog=ItCastCn;Integrated Security=True";
            using (SqlConnection sc = new SqlConnection(constr))
            {
                string sqlsentenc = "insert into TblClass values('666','7777');delete from TblClass where tClassId in(1,2,3);update TblClass set tClassName='sb1' where tClassId=7";
                using (SqlCommand command = new SqlCommand(sqlsentenc, sc))
                {
                    sc.Open();
                    //注册事件
                    command.StatementCompleted += new System.Data.StatementCompletedEventHandler(command_StatementCompleted);
                    command.ExecuteNonQuery();
                }
            }
            Console.Read();
        }

        
        static void command_StatementCompleted(object sender, System.Data.StatementCompletedEventArgs e)
        {
            Console.WriteLine(e.RecordCount);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
namespace 数据导入与导出
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1,导入   2,导出");
                string choose = Console.ReadLine();
                if (choose == "1")
                {
                    Include();
                }
                else if (choose=="2")
                {
                    Output();
                }
                else
                {
                    Console.WriteLine("输入错误");   
                }
            }
        }

        static string constr = "Data Source=Y-4988160916C94;Initial Catalog=ItCastCn;Integrated Security=True";
        private static void Output()
        {
            
            using (SqlConnection sc=new SqlConnection(constr))
            {
                string sqlstr = "select * from TblClass";
                using (SqlCommand command=new SqlCommand(sqlstr,sc))
                {
                    using (StreamWriter writer=new StreamWriter("1.txt",false,Encoding.UTF8))
                    {
                        sc.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string classname = reader.GetString(1);
                                    string classdesc = reader.GetString(2);
                                    writer.WriteLine(classname+","+classdesc);
                                }
                            }
                            else
                            {
                                Console.WriteLine("无数据");
                            }
                        }    
                    }
                    
                }    
            }
        }

        private static void Include()
        {
            using (StreamReader sr=new StreamReader("1.txt"))
            {
                string line=null;
                using (SqlConnection sc = new SqlConnection(constr))
                {
                    string sqlstr = "insert into newtable values(@name,@desc)";
                    using (SqlCommand command=new SqlCommand(sqlstr,sc))
                    {
                        sc.Open();
                        //先定义两个SQLParameter对象但不用赋值
                        SqlParameter classname = new SqlParameter("@name", System.Data.SqlDbType.VarChar, 50);
                        SqlParameter classdesc = new SqlParameter("@desc", System.Data.SqlDbType.VarChar, 50);
                        //记得这里要添加到command中
                        command.Parameters.Add(classname);
                        command.Parameters.Add(classdesc);
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] strs = line.Split(',');
                            //每次都给sqlparamter对象赋值
                            classname.Value = strs[0];
                            classdesc.Value = strs[1];
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            Console.WriteLine("ok");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace 与数据库绑定
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            List<Person> list = new List<Person>();
            //用List<Person>来保存多行数据
            string constr = "Data Source=Y-4988160916C94;Initial Catalog=ItCastCn;Integrated Security=True";
            using (SqlConnection sc = new SqlConnection(constr))
            {
                string sqlsentence = "select * from TblClass";
                Person p;
                using (SqlCommand scmand = new SqlCommand(sqlsentence, sc))
                {
                    sc.Open();
                    using (SqlDataReader reader = scmand.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                p = new Person();//每行数据都用一个新的Person保存
                                //p.tClassId = (int?)reader[0];//运行时reader[0]得到
                                p.tClassId = reader.GetInt32(0);//如果写成GetIn16会报错
                                p.tClassName = reader.GetString(1);
                                p.tClassDesc = reader.GetString(2);
                                list.Add(p);//把数据添加到list
                            }
                        }
                    }
                }
            
            }
            dataGridView1.DataSource = list;
        }
    }
    class Person//专门创建一个类来保存特定表的数据
    { 
        public int? tClassId { get; set; }
        public string  tClassName { get; set; }
        public string tClassDesc { get; set; }
    }
}

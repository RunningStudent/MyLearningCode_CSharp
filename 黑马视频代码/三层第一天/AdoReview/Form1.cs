using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace AdoReview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select COUNT(*) from login where userName=@name and userPsw=@psw";
            SqlParameter[] pas = new SqlParameter[]{
                new SqlParameter("@name",textBox1.Text.Trim()),
                new SqlParameter("@psw",textBox2.Text)
            };
            int count = (int)SqlHelper.ExecuteScalar(sql, CommandType.Text, pas);
            if (count>=1)
            {
                MessageBox.Show("成功");
            }
            else
            {
                MessageBox.Show("失败");
            }
        }

        

    }
}

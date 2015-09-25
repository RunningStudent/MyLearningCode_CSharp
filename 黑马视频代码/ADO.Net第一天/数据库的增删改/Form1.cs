using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace 数据库的增删改
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //先创建连接字符串
            string constr = "Data Source=Y-4988160916C94;Initial Catalog=ItCastCn;Integrated Security=true";
            using (SqlConnection sc = new SqlConnection(constr))//创建连接对象
            {
                //创建查询语句
                string sqlSentence = string.Format(@"insert into TblClass values('{0}','{1}')", tBName.Text, tBDesc.Text);
                using (SqlCommand scm = new SqlCommand(sqlSentence,sc))//创建数据库操作对象
                { 
                    //尽可能让数据库打开的时间少点
                    sc.Open();
                    scm.ExecuteNonQuery();
                    //当执行insert,delete,update语句时，一般使用该方法调动
                    MessageBox.Show("OK");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=Y-4988160916C94;Initial Catalog=ItCastCn;Integrated Security=true";
            
            using (SqlConnection sc = new SqlConnection(constr))
            {
                string sqlSentence = string.Format(@"delete from TblClass where tClassId={0}", tBId.Text);
                using (SqlCommand scm = new SqlCommand(sqlSentence, sc))
                {
                    sc.Open();
                    scm.ExecuteNonQuery();
                    MessageBox.Show("delete Complete");
                }
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=Y-4988160916C94;Initial Catalog=ItCastCn;Integrated Security=true";
            using (SqlConnection sc = new SqlConnection(constr))
            {
                string sqlSentence = string.Format(@"update TblClass set tClassName='{0}',tClassDesc='{1}' where tClassId={2}", tBName.Text, tBDesc.Text,tBId.Text);
                using (SqlCommand scm = new SqlCommand(sqlSentence, sc))
                {
                    sc.Open();
                    scm.ExecuteNonQuery();
                    MessageBox.Show("Updata Complete");
                }
            }
        }
    }
}

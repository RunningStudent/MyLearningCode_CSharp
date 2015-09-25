using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 多条件搜索
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        
        /// <summary>
        /// 弹出多条件搜索的sql语句
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string sqlh="select *　from XXXX ";
            List<string> selectKey = new List<string>();
            List<SqlParameter> selectPmt = new List<SqlParameter>();
            if (textBox1.Text.Trim() != "")
            {
                selectKey.Add("biao1 like @tj1");
                selectPmt.Add(new SqlParameter("@tj3", textBox1.Text.Trim()));
            }
            if (textBox2.Text.Trim() != "")
            {
                selectKey.Add("biao2 like @tj2");
                selectPmt.Add(new SqlParameter("@tj3", textBox1.Text.Trim()));
            }
            if (textBox3.Text.Trim() != "")
            {
                selectKey.Add("biao3 like @tj3");
                selectPmt.Add(new SqlParameter("@tj3", textBox1.Text.Trim()));
            }
            if (sqlh.Count()>0)
            {
                MessageBox.Show(sqlh + " where " + string.Join(" and ", selectKey.ToArray()));
            }
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 使用属性面板生成连接字符串
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCreateSB_Click(object sender, EventArgs e)
        {
            //创建连接字符串类,并与propertyGrid绑定,使属性面板显示SqlConnection的属性数据
            //DateScoure在使用Integrated Security时,赋值为.,表示直接使用本地服务器
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            //把scsb装到属性面板给使用者修改
            propertyGrid1.SelectedObject = scsb;
        }

        private void btnShowSB_Click(object sender, EventArgs e)
        {
            //获得属性面板所设置的值,而这个值装在SqlConnectionStringBuilder中
            SqlConnectionStringBuilder scsb = (SqlConnectionStringBuilder)propertyGrid1.SelectedObject;
            txtSB.Text = scsb.ConnectionString;
        }
    }
}

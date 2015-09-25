using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 使用MD5的窗体登入
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int userid;//用户信息在数据库中的id
        private string psw = "";//保存从数据库得到的密码
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //获取用户输入
            string userName = txtUserName.Text;
            //直接转换成MD5
            string md5PassWord = CommonHelper.GetMD5FromString(txtPassWord.Text);

            string sql = "select CC_AutoId,CC_UserName,CC_LoginPassword from T_Seats where CC_LoginID=@user";
            bool hasUser = false;//保存是否有这个用户
            string user = "";
            using (SqlDataReader sr = SqlHelper.ExecuteReader(sql, CommandType.Text, new SqlParameter("@user", userName)))
            {
                //如果有数据说明有这个用户
                if (sr.HasRows)
                {
                    hasUser = true;
                    if (sr.Read())
                    {
                        psw = sr.GetString(2);
                        user = sr.GetString(1);
                        userid = sr.GetInt32(0);
                    }
                }
            }

            if (!hasUser)
            {
                MessageBox.Show("用户不存在");
                btnChangePsw.Enabled = false;
            }
            else
            {
                if (psw==md5PassWord)
                {

                    MessageBox.Show("登入成功");
                    btnChangePsw.Enabled = true;
                    label3.Text = "欢迎" + user;
                }
                else
                {
                    MessageBox.Show("密码错误");
                    btnChangePsw.Enabled = false;
                }
            }
        }

        private void btnChangePsw_Click(object sender, EventArgs e)
        {
            //可以用静态来保存多个窗口都用的到的数据
            fmChangePsw fm = new fmChangePsw(this.psw, this.userid);
            fm.Show();
            label3.Text = "";
            btnChangePsw.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmRegister fm = new fmRegister();
            fm.Show();
        }
    }
}

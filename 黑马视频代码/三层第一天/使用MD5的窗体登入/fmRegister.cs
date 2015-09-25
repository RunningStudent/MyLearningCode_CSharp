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
    public partial class fmRegister : Form
    {
        public fmRegister()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string loginId = txtLoginId.Text;
            string psw = CommonHelper.GetMD5FromString(txtPsw.Text);
            string sql = "insert into T_seats(CC_LoginID,CC_LoginPassWord,CC_UserName) values(@loginId,@psw,@userName)";
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@loginId",loginId),
                new SqlParameter("@psw",psw),
                new SqlParameter("@userName",userName)
            };
            int result = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
            if (result > 0)
            {
                MessageBox.Show("注册成功");
                this.Close();
            }
        }
    }
}

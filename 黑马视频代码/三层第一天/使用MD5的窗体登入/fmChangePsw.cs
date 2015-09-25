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
    public partial class fmChangePsw : Form
    {
        public fmChangePsw()
        {
            InitializeComponent();
        }

        private string oldPsw;
        private int userId;
        public fmChangePsw(string oldPsw,int userId)
        {
            this.oldPsw = oldPsw;
            this.userId = userId;
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string inputOldpsw = CommonHelper.GetMD5FromString(txtOldPsw.Text);
            if (txtNewPsw.Text != txtComfirmPsw.Text)
            {
                MessageBox.Show("两次输入错误!");
                return;
            }
            if (inputOldpsw != this.oldPsw)
            {
                MessageBox.Show("旧密码错误!");
                return;
            }

            string inputNewpsw = CommonHelper.GetMD5FromString(txtNewPsw.Text);
            string sql = "update T_seats set CC_LoginPassword=@psw where CC_AutoId=@userid";
            SqlParameter[] pars = new SqlParameter[]{
                new SqlParameter("@psw",inputNewpsw),
                new SqlParameter("@userid",this.userId)
            };

            int result = SqlHelper.ExecuteNonQuery(sql, CommandType.Text, pars);
            if (result >= 0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }

        }
    }
}

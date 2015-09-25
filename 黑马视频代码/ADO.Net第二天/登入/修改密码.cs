using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 登入
{
    public partial class 修改密码 : Form
    {
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }
        public 修改密码()
        {
            InitializeComponent();
        }

        //能获取账号和数据主键的构造函数
        public 修改密码(string userName, int userId)
        {
            InitializeComponent();
            this._userName = userName;
            this._userId = userId;
        }



        //窗口加载时把账号显示到窗体上
        private void 修改密码_Load(object sender, EventArgs e)
        {
            label1.Text = "用户名:" + UserName;
        }

        //确认修改按钮
        private void btnChange_Click(object sender, EventArgs e)
        {
            //先判断两次输入是否相同
            if (txtNewPsw.Text != txtSencondPsw.Text)
            {
                MessageBox.Show("两次输入密码不同,请重新输入");
                txtNewPsw.Text = "";
                txtSencondPsw.Text = "";
                txtNewPsw.Focus();
            }
            else
            {
                string constr = "Data Source=Y-4988160916C94;Initial Catalog=ItCastCn;Integrated Security=True";
                using (SqlConnection sc=new SqlConnection(constr))
                {
                    string sqlstr = string.Format("update Tblogin set loginPwd='{0}' where autoid={1}", txtNewPsw.Text, UserId);
                    using (SqlCommand command=new SqlCommand(sqlstr,sc))
                    {
                        sc.Open();
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("修改成功");
                this.Close();
            }
        }
    }
}

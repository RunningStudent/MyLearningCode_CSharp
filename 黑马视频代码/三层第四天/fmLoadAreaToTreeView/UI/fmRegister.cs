using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fmLoadArea.BLL;
using fmLoadArea.Model;

namespace fmLoadArea.UI
{
    public partial class fmRegister : Form
    {
        public fmRegister()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //数据采集
            UserMsg um = new UserMsg();
            string loginId = textBox1.Text;
            string psw1 = textBox2.Text;
            string psw2 = textBox3.Text;
            string userName = textBox4.Text;
            if (psw1 != psw2)
            {
                MessageBox.Show("两次输入不正确");
                return;
            }
            else
            {
                um.CC_LoginId = loginId;
                um.CC_UserName = userName;
                um.CC_LoginPassWord = psw1;
                T_SeatsBll bll = new T_SeatsBll();
                if (bll.Register(um) > 0)
                {
                    MessageBox.Show("注册成功");
                }
            }

        }
    }
}

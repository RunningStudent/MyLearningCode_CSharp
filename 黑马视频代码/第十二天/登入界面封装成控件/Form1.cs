using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 登入界面封装成控件
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ucLoginControl1.login += new Action<object, UCEventArgs>(ucLoginControl1_login);
        }

        void ucLoginControl1_login(object arg1, UCEventArgs arg2)
        {
            if (arg2.UserName == "admin" && arg2.UserPassword == "123456")
            {
                //arg2.IsPass = true;
                UCLoginControl LC = (UCLoginControl)arg1;
                LC.BackColor = Color.Red;
            }
            else
            {
                UCLoginControl LC = (UCLoginControl)arg1;
                LC.BackColor = Color.Blue;
            }
        }
    }
}

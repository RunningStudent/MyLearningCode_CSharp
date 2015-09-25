using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 模拟三层.BLL;
using 模拟三层.Model;

namespace 模拟三层.UI
{

    /// <summary>
    /// 第二种登入窗口,能够实现判断用户名是否存在,能登入修改密码窗口
    /// </summary>
    public partial class fmLogin2 : Form
    {
        public fmLogin2()
        {
            InitializeComponent();
        }


        /// <summary>
        /// login2窗体的登入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string uid = textBox1.Text;
            string psw = textBox2.Text;
            TblSeatBLL bll = new TblSeatBLL();
            模拟三层.Model.UserMsg um = null;
            LoginReasult result = bll.Login2(uid, psw, out um);
            //判断情况并作出回应
            switch (result)
            {
                case LoginReasult.Succeed: 
                    MessageBox.Show("登入成功");
                    label3.Text = "欢迎" + um.UserName;
                    GlobalFmData.autoId = um.AutoId;
                    btnChangePsw.Enabled = true;
                    break;
                case LoginReasult.UserNameNoExist: MessageBox.Show("用户名不存在");
                    break;
                case LoginReasult.PswError: MessageBox.Show("密码错误");
                    break;
            }

        }


        /// <summary>
        /// 修改密码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChangePsw_Click(object sender, EventArgs e)
        {
            fmChangePsw fm = new fmChangePsw();
            fm.Show();
        }
    }
}

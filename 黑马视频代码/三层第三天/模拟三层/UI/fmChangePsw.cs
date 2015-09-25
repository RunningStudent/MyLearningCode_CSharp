using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 模拟三层.BLL;

namespace 模拟三层.UI
{
    public partial class fmChangePsw : Form
    {
        public fmChangePsw()
        {
            InitializeComponent();
        }

        private void fmChangePsw_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string oldPsw = textBox1.Text;
            string newPsw1 = textBox2.Text;
            string newPsw2 = textBox3.Text;
            TblSeatBLL bll = new TblSeatBLL();
            ChangePswReasult reasult = bll.ChangePsw(GlobalFmData.autoId, oldPsw, newPsw1, newPsw2);
            switch (reasult)
            {
                case ChangePswReasult.Successed:
                    MessageBox.Show("修改成功");
                    break;
                case ChangePswReasult.DifPsw:
                    MessageBox.Show("两次密码不同");
                    break;
                case ChangePswReasult.ErrorOldPsw:
                    MessageBox.Show("旧密码错误");
                    break;
                case ChangePswReasult.Failed:
                    MessageBox.Show("未知错误,修改失败");
                    break;
                default:
                    break;
            }
        }
    }
}

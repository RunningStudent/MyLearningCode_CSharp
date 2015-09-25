using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 大管家模式的窗体传值
{
    public partial class ParentFm : Form
    {

        public List<IChangeTxt> list;
        public ParentFm()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (list==null)
            {
                return;
            }
            foreach (var item in list)
            {
                item.ChangeTxt(this.txtSendMsg.Text);
            }
        }
    }
}

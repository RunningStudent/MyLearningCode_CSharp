using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 编写三连击触发事件按钮
{
    public partial class UCThreeClickBtn : UserControl
    {
        public UCThreeClickBtn()
        {
            InitializeComponent();
        }
        private int cout = 0;//点击次数
        public event Action ThreeClick;
        private void button1_Click(object sender, EventArgs e)
        {
            if (ThreeClick != null)
            {
                cout++;
                if (cout == 3)
                {
                    ThreeClick();
                    cout = 0;
                }
            }
        }
    }
}

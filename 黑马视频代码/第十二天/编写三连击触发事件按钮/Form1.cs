using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 编写三连击触发事件按钮
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ucThreeClickBtn1.ThreeClick += new Action(ucThreeClickBtn1_ThreeClick);
            ucThreeClickBtn1.ThreeClick += new Action(ucThreeClickBtn1_ThreeClick1);
        }

        void ucThreeClickBtn1_ThreeClick1()
        {
            MessageBox.Show("三击事件2complete!!");
        }

        void ucThreeClickBtn1_ThreeClick()
        {
            MessageBox.Show("三击事件complete!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 窗体委托传值
{
    public delegate void del(string str);
    public partial class Form2 : Form
    {
        del d;
        public Form2(del d)
        {
            InitializeComponent();
            this.d=d;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            d(textBox1.Text);
        }

       
    }
}

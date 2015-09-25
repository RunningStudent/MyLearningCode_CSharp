using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 资料管理器_数据库_
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string name;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                this.name = textBox1.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入正确名称");
            }
        }
        
    }
}

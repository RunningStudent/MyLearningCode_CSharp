using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 窗体传值
{
    public partial class Childfm2 : Form
    {
        public Childfm2()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 能传递委托的构造函数
        /// </summary>
        /// <param name="method"></param>
        public Childfm2(Action<string> method) 
            : this() 
        {
            method+=ChangeTxt;
        }

        /// <summary>
        /// 改变文本框内容方法,给委托用的
        /// </summary>
        /// <param name="str"></param>
        public void ChangeTxt(string str)
        {
            this.textBox1.Text=str;
        }

        /// <summary>
        /// 修改文本内容,给事件用的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChangeTxtByEvent(object sender, EventArgs e)
        {
            TxtChangeEventArg arg = (TxtChangeEventArg)e;
            this.textBox1.Text = arg.Txt;
        }
    }
}

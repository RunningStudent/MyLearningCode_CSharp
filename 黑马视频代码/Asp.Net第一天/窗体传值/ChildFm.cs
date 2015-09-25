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
    public partial class ChildFm : Form
    {

        public ChildFm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 能传递委托的构造函数,但是要加ref,不知道为什么
        /// </summary>
        /// <param name="fun"></param>
        public ChildFm(ref Action<string> fun)
            : this()
        {
            //给父窗体的委托注册方法
            fun += ChangeTxt;

        }
        /// <summary>
        /// 改变文本框的方法,给委托用的
        /// </summary>
        /// <param name="str"></param>
        public void ChangeTxt(string str)
        {
            this.txtChildren.Text = str;
        }

        


        /// <summary>
        /// 修改文本内容,给事件用的
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ChangeTxtByEvent(object sender, EventArgs e)
        {
            TxtChangeEventArg arg = (TxtChangeEventArg)e;
            this.txtChildren.Text = arg.Txt;
        }
    }
}

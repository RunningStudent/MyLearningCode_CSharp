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
    class TxtChangeEventArg : EventArgs
    {
        public string Txt { get; set; }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //委托
        Action<string> ChangeChildTxt;
        //事件
        public event EventHandler TxtChangeEvent;


        //窗体1
        ChildFm fm1 = new ChildFm();
        //窗体2
        Childfm2 fm2 = new Childfm2();




        /// <summary>
        /// 修改子窗体文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFather_Click(object sender, EventArgs e)
        {
            //执行事件方法
            TxtChangeEvent(this, new TxtChangeEventArg() { Txt = txtFather.Text });
        }



        /// <summary>
        /// 弹出子窗体1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            #region 委托方式
            ////传值子窗体,传委托,非要ref才有用!!!!
            //ChildFm fm = new ChildFm(ref ChangeChildTxt);
            //fm.Show();
            #endregion
            fm1.Show();
        }

        /// <summary>
        /// 弹出子窗体2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            #region 传值子窗体,传委托
            //Childfm2 fm = new Childfm2(ChangeChildTxt);
            //fm.Show();
            #endregion
            fm2.Show();
        }

        /// <summary>
        /// 窗体加载,给事件注册子窗体改变文本框内容的方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //注册窗体1的修改文本框的方法
            TxtChangeEvent += fm1.ChangeTxtByEvent;
            TxtChangeEvent += fm2.ChangeTxtByEvent;
        }

    }
}

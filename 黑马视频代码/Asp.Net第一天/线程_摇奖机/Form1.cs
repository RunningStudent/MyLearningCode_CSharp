using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace 线程_摇奖机
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Thread td;
        /// <summary>
        /// 点击摇奖,再点停止,再点继续
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRoll_Click(object sender, EventArgs e)
        {
            //注意短路性,如果两个判断相反则会爆出为实例化错误
            if (td != null && td.IsAlive)
            {
                td.Abort();
                return;
            }

            td = new Thread(() =>
            {
                Random r = new Random(DateTime.Now.Second);
                while (true)
                {
                    Thread.Sleep(200);//设置休眠,使得显示的摇奖效果不过快
                    //有一个if,实现跨线程
                    if (lbRoll1.InvokeRequired)//如果该标签是其他线程创建的
                    {
                        //不能用Lambda
                        //在创建该标签的线程执行该方法
                        lbRoll1.Invoke(new Action<Random>((rr) =>
                        {
                            lbRoll1.Text = rr.Next(0, 10).ToString();
                            lbRoll2.Text = rr.Next(0, 10).ToString();
                            lbRoll3.Text = rr.Next(0, 10).ToString();
                            lbRoll4.Text = rr.Next(0, 10).ToString();
                        }
                        ), r);

                    }
                    else//其实这个else在这里没用
                    {
                        lbRoll1.Text = r.Next(0, 10).ToString();
                        lbRoll2.Text = r.Next(0, 10).ToString();
                        lbRoll3.Text = r.Next(0, 10).ToString();
                        lbRoll4.Text = r.Next(0, 10).ToString();
                    }
                }

            });

            td.IsBackground = true;
            td.Start();
        }
    }
}

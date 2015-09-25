using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace 摇奖机2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //保存标签的集合
        private List<Label> lableLists;


        //保存摇奖机的状态
        private bool IsRoll=false;
        /// <summary>
        /// 窗体载入时候,创建标签对象们,并保存起来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            lableLists = new List<Label>();
            for (int i = 0; i < 5; i++)
            {
                Label l = new Label();
                l.Text = "0";
                l.Location = new Point(100 + i * 100, 150);
                lableLists.Add(l);//标签保存私有集合中

                this.Controls.Add(l);//把标签载入到窗体中
            }
        }

        /// <summary>
        /// 开始摇
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRoll_Click(object sender, EventArgs e)
        {
            IsRoll = true;
            //创建一个线程进行随机生成数字并显示
            Thread td = new Thread(() =>
            {
                Random r = new Random();
                //不断循环变换
                while (IsRoll)
                {
                    foreach (var item in lableLists)
                    {
                        //跨线程处理
                        if (item.InvokeRequired)
                        {
                            item.Invoke(new Action<Random>((rr) =>
                            {
                                item.Text = rr.Next(0, 10).ToString();
                            }), r);
                        }
                        else
                        {
                            item.Text = r.Next(0, 10).ToString();
                        }
                    }
                }
            });

            td.IsBackground = true;
            td.Start();

        }

        /// <summary>
        /// 停止按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopRool_Click(object sender, EventArgs e)
        {
            IsRoll = false;
        }
    }
}

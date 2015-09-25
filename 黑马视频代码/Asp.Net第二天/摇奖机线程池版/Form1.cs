using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace 摇奖机线程池版
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Label> list;
        bool isRoll = false;
        /// <summary>
        /// 初始时,创建标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            list = new List<Label>();
            for (int i = 0; i < 4; i++)
            {
                Label l = new Label();
                l.Location = new Point(100*i, 100);
                l.Text = "1";
                this.Controls.Add(l);
                list.Add(l);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            isRoll = !isRoll;
            
            ThreadPool.QueueUserWorkItem((d) =>
            {
                Random r = new Random();
                while (isRoll)
                {
                    foreach (var item in list)
                    {
                        if (item.InvokeRequired)
                        {
                            item.Invoke(new Action<int>((randomNum) =>
                            {
                                item.Text = randomNum.ToString();
                            }), r.Next(0, 9));
                        }
                    }
                }
            });
        }


    }
}

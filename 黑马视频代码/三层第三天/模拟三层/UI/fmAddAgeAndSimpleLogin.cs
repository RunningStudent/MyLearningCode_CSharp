﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 模拟三层.BLL;

namespace 模拟三层.UI
{
    public partial class fmAddAgeAndSimpleLogin : Form
    {
        public fmAddAgeAndSimpleLogin()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 年龄+1按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            TblPersonBLL bll = new TblPersonBLL();
            if (bll.AddAge(Convert.ToInt16(textBox1.Text)))
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("not ok");
            }
        }

        /// <summary>
        /// 登入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string uid =textBox2.Text.Trim();
            string psw = textBox3.Text;
            TblSeatBLL bll = new TblSeatBLL();
            if (bll.Login(uid, psw))
            {
                MessageBox.Show("ok");
            }
            else
            {
                MessageBox.Show("失败");
            }
        }
    }
}

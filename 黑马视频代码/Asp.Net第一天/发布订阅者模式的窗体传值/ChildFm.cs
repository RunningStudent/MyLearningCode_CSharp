﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 发布订阅者模式的窗体传值
{
    public partial class ChildFm : Form,IChangeTxt
    {
        public ChildFm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 修改文本框内容
        /// </summary>
        /// <param name="str"></param>
        public void ChangeTxt(string str)
        {
            this.txtAccept.Text = str;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 用控件进行对数据库的增删改查
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using 用代码生成器生成的代码对数据库操作.UI;

namespace 用代码生成器生成的代码对数据库操作
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

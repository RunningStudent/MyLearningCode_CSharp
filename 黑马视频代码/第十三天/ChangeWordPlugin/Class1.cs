using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditPluginInterface;
using System.Windows.Forms;

namespace ChangeWordPlugin
{
    public class WordToUpper:EditInterface
    {
        public string name
        {
            get { return "转大写"; }
        }

        public void Run(TextBox txtB)
        {
            txtB.Text=txtB.Text.ToUpper();
        }
    }

    public class AddTime : EditInterface
    {
        public string name
        {
            get { return "添加时间"; }
        }

        public void Run(TextBox txtB)
        {
            txtB.Text += DateTime.Now.ToString();
        }
    }

    public class ChangeFont : EditInterface
    {
        public string name
        {
            get { return "字体设置"; }
        }

        public void Run(TextBox txtB)
        {
            FontSet fontWindow = new FontSet(txtB);
            fontWindow.Show();
        }
    }


}

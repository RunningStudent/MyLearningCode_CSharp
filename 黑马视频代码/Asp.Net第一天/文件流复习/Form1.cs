using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 文件流复习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 打开文件加载到文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd=new OpenFileDialog())
            {
                if (ofd.ShowDialog()!= System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                string path = ofd.FileName;
                txtPath.Text = path;
                using (StreamReader sr=new StreamReader(path,Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        txtContent.Text += sr.ReadLine();
                    }
                }
            }


        }


        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sf=new SaveFileDialog())
            {
                sf.Filter = "文本类型(*.txt,*abc)|*.txt;*.abc|所有类型|*.*";
                if (sf.ShowDialog()!= System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                using (FileStream fs=new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter sw=new StreamWriter(fs))
                    {
                        sw.Write(txtContent.Text);
                    }
                }
            }
        }




    }
}

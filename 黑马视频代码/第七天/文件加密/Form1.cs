using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 文件加密
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string source = tBSource.Text;
            string target = tBtarget.Text;
            Encrypt(source, target);
            MessageBox.Show("OK");
        }

        private void Encrypt(string source, string target)
        {
            using(FileStream fsRead=new FileStream(source,FileMode.Open,FileAccess.Read))
            {
                using(FileStream fsWrite=new FileStream(target,FileMode.Create,FileAccess.Write))
                {
                    byte[] byts = new byte[1024 * 1024 * 1];
                    int trueLength;
                    while (true)
                    {
                        trueLength=fsRead.Read(byts, 0, byts.Length);
                        if (trueLength == 0)
                        {
                            break;
                        }
                        //加密,把路径反过来就是解密
                        for (int i = 0; i < byts.Length; i++)
                        {
                            byts[i] = (byte)(int.MaxValue - byts[i]);
                        }
                        fsWrite.Write(byts, 0, trueLength);
                    }
                }
            }
        }
    }
}

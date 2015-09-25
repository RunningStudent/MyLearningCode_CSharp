using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 发布订阅者模式的窗体传值
{
    public partial class MainFm : Form
    {
        public MainFm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 子窗体们
        /// </summary>
        private List<IChangeTxt> list;




        private void btnSend_Click(object sender, EventArgs e)
        {
            if (list==null)
            {
                return;
            }
            //遍历执行修改子窗体文本框方法
            foreach (var item in list)
            {
                item.ChangeTxt(this.txtSendMsg.Text);
            }
        }

        private void MainFm_Load(object sender, EventArgs e)
        {
            list = new List<IChangeTxt>();
            //创建子窗体
            ChildFm fm=new ChildFm();
            //保存到集合中
            list.Add(fm);
            fm.Show();
        }
    }
}

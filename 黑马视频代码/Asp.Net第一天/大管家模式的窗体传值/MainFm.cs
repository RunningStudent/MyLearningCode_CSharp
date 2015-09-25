using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 大管家模式的窗体传值
{
    public partial class MainFm : Form
    {
        public MainFm()
        {
            InitializeComponent();
        }

        //用一个大窗体管理窗体,做的两个窗体间的解耦和


        /// <summary>
        /// 显示父窗体与子窗体并使两者关联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowParentAndSonFm_Click(object sender, EventArgs e)
        {
            ChildFm fm = new ChildFm();
            ParentFm Pfm = new ParentFm();
            
            Pfm.list = new List<IChangeTxt>();
            //使两个窗体关联
            Pfm.list.Add(fm);

            fm.Show();
            Pfm.Show();


        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using fmLoadArea.BLL;
using fmLoadArea.Model;

namespace fmLoadArea.UI
{
    public partial class fmLoadAreaToTreeView : Form
    {
        public fmLoadAreaToTreeView()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 加载按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAreaDataRec(0, treeView1.Nodes);
        }

        /// <summary>
        /// 递归加载数据到TreeNode
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="treeNodes">TreeNode集合</param>
        /// 由于这个方法的参数有TreeNode,所以不适合写在逻辑层
        public void LoadAreaDataRec(int pid, TreeNodeCollection treeNodes)
        {
            TblAreaBll bll = new TblAreaBll();
            List<Area> list=bll.GetAreaDataByAreaPID(pid);
            foreach (var item in list)
            {
                TreeNode newNode=treeNodes.Add(item.AreaName);
                newNode.Tag = item.AreaId;
                LoadAreaDataRec(item.AreaId, newNode.Nodes);
            }
        }


        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            TblAreaBll bll = new TblAreaBll();
            bll.RecDeleteAreaData((int)treeView1.SelectedNode.Tag);
            treeView1.SelectedNode.Remove();
        }



    }
}

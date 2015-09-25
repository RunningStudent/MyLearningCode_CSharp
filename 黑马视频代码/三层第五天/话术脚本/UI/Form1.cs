using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 话术脚本.BLL;
using 话术脚本.Model;

namespace 话术脚本.UI
{
    public partial class Form1 : Form
    {

        T_ScriptBLL bll = new T_ScriptBLL();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Reflash();
        }


        /// <summary>
        /// 更新TreeView
        /// </summary>
        private void Reflash()
        {
            treeView1.Nodes.Clear();
            LoadDateToTree(0, treeView1.Nodes);
        }


        /// <summary>
        /// 递归加载数据到TreeNode
        /// </summary>
        /// <param name="id"></param>
        /// <param name="treeNodeCollection"></param>
        private void LoadDateToTree(int id, TreeNodeCollection treeNodeCollection)
        {
            List<Scripts> list = bll.GetSonNodesById(id);

            foreach (var item in list)
            {
                TreeNode newNode = treeNodeCollection.Add(item.Title);
                newNode.Tag = item.ID;
                LoadDateToTree(item.ID, newNode.Nodes);
            }
        }

        /// <summary>
        /// 修改节点
        /// </summary>
        /// <param name="s"></param>
        private void ChangeNode(Scripts s)
        {
            treeView1.SelectedNode.Text = s.Title;
            textBox1.Text = s.Msg;
        }


        /// <summary>
        /// 选择treeView显示Msg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                textBox1.Text = bll.GetMsgById((int)e.Node.Tag);
            }
        }

        #region 菜单点击事件
        /// <summary>
        /// 添加根节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加根节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddNode fm = new fmAddNode(Reflash, 0);
            fm.Show();
        }


        /// <summary>
        /// 添加子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmAddNode fm = new fmAddNode(Reflash, (int)treeView1.SelectedNode.Tag);
            fm.Show();
        }


        /// <summary>
        /// 删除节点,及其子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                bll.RecDelete((int)treeView1.SelectedNode.Tag);
                treeView1.SelectedNode.Remove();
            }
        }

        /// <summary>
        /// 编辑,弹出窗口编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 编辑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scripts s=new Scripts();
            s.ID = (int)treeView1.SelectedNode.Tag;
            s.Msg = textBox1.Text;
            s.Title = treeView1.SelectedNode.Text;
            fmEdit fm=new fmEdit(s,ChangeNode);
            fm.Show();
        }
        #endregion



        /// <summary>
        /// 搜索按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKey = txtScearch.Text.Trim();
            SearchNodeText(searchKey,treeView1.Nodes);
        }


        /// <summary>
        /// 搜索,查找结果红色高亮,自动展开
        /// </summary>
        /// <param name="searchKey"></param>
        private void SearchNodeText(string searchKey,TreeNodeCollection treeNode)
        {
            
            foreach (TreeNode item in treeNode)
            {
                if (item.Text.Contains(searchKey))
                {
                    item.BackColor = Color.Red;
                    item.EnsureVisible();//确保本节点可见,即自动张开
                }
                else
                {
                    //若节点名与关键字不同,恢复颜色
                    item.BackColor = this.BackColor;
                }
                SearchNodeText(searchKey, item.Nodes);
            }
        }




    }
}

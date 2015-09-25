using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace 文件浏览器
{
    public partial class Form1 : Form
    {

        private string txtPath;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 菜单事件:文件载入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 文件载入夹ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.MyComputer;
            fbd.ShowDialog();
            string path = fbd.SelectedPath;
            if (path != null&&path!="")
            {
                InputFileAndDirectoris(path, treeView1.Nodes);
            }
        }
        /// <summary>
        /// 递归载入所有文件及其文件夹方法
        /// </summary>
        /// <param name="path"></param>
        /// <param name="treeNodeCollection"></param>
        private void InputFileAndDirectoris(string path, TreeNodeCollection tree)
        {
            string[] files = null;
            string[] directoris = null;
            files = Directory.GetFiles(path);
            directoris = Directory.GetDirectories(path);
            TreeNode tN = null;
            foreach (var item in directoris)
            {
                tN = tree.Add(Path.GetFileName(item));
                InputFileAndDirectoris(item, tN.Nodes);
            }
            foreach (var item in files)
            {
                tN=tree.Add(Path.GetFileName(item));
                tN.Tag = item;
            }
        }



        /// <summary>
        /// 选中TreeNode双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

            //tBTXT.Text= File.ReadAllText(treeView1.SelectedNode.Tag.ToString(),Encoding.Default);白痴方法
            if (e.Node.Tag != null)
            {
                if (Path.GetExtension(e.Node.Tag.ToString()) != ".txt")
                {
                    MessageBox.Show("目前只能打开txt文件");
                    return;
                }
                tBTXT.Text = File.ReadAllText(e.Node.Tag.ToString(), Encoding.Default);//e在这里就是被点击的节点
                txtPath = treeView1.SelectedNode.Tag.ToString();
            }
        }

        /// <summary>
        /// 使用文件对话框打开单个文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打开单个文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择文件";
            ofd.InitialDirectory = @"D:\学习";
            ofd.Multiselect = true;
            ofd.Filter = "文本文件|*.txt;*.doc|所有文件|*.*";
            ofd.ShowDialog();
            string[] paths = ofd.FileNames;
            TreeNode nt = null;
            foreach (var item in paths)
            {
                nt = treeView1.Nodes.Add(Path.GetFileName(item));
                nt.Tag = item;
            }
        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            File.WriteAllText(txtPath, tBTXT.Text, Encoding.Default);
            MessageBox.Show("保存成功");
        }
    }
}

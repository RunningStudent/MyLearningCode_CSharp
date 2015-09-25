using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace TreeView练习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 加载文件夹和文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputFileAndDir_Click(object sender, EventArgs e)
        {
            string path = tBFilePath.Text;
            InputFileAndDirectory(path, treeView1.Nodes);//treeView1.Nodes代表根目录的集合
        }


        /// <summary>
        /// 加载文件夹和文件的递归方法
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tree"></param>
        private void InputFileAndDirectory(string path, TreeNodeCollection tree)
        {
            string[] directories = Directory.GetDirectories(path);
            foreach (var item in directories)//不用判断是否有文件,如果没有,foreach不会执行
            {
                TreeNode sonTrees = tree.Add(Path.GetFileName(item));
                InputFileAndDirectory(item, sonTrees.Nodes);
            }
            string[] files = Directory.GetFiles(path);
            foreach (var item in files)
            {
                tree.Add(Path.GetFileName(item));
            }
        }
        
        /// <summary>
        /// 加载文件夹和txt文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInputTxt_Click(object sender, EventArgs e)
        {
            string path = tBFilePath.Text;
            InputDirectoryAndTxt(path, treeView1.Nodes);//treeView1.Nodes代表根目录的集合

        }


        /// <summary>
        /// 加载文件夹和txt文件的递归方法
        /// </summary>
        /// <param name="path"></param>
        /// <param name="tree"></param>
        private void InputDirectoryAndTxt(string path, TreeNodeCollection tree)
        {
            string[] directories = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path,"*.txt");
            foreach (var item in directories)//不用判断是否有文件,如果没有,foreach不会执行
            {
                TreeNode sonTrees = tree.Add(Path.GetFileName(item));
                InputDirectoryAndTxt(item, sonTrees.Nodes);
            }
            foreach (var item in files)
            {
                tree.Add(Path.GetFileName(item));
            }
        }
    }
}

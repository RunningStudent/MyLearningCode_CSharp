using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace 把xml加入TreeView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XDocument document = XDocument.Load("rss_sportslq.xml");
            //获得根节点
            XElement rootNode = document.Root;
            TreeNode rootTreeNode=treeView1.Nodes.Add(rootNode.Name.ToString());
            //递归获得子节点
            GetSonNodes(rootTreeNode, rootNode);
            //这里传入的是TreeNode和XElement

        }

        private void GetSonNodes(TreeNode rootTreeNode, XElement rootNode)
        {
            //先尝试载入根节点中的子节点
            foreach (XElement item in rootNode.Elements())//在xml根节点下的子节点们中遍历
            {
                TreeNode newNode = rootTreeNode.Nodes.Add(item.Name.ToString());
                //把子节点的名字加入到TreeView这个节点的子节点的集合中
                if (item.Elements().Count() == 0)//如果xml根节点的子节点们中有孙节点的则进行递归,否则把节点内容加入
                {
                    newNode.Nodes.Add(item.Value.ToString());
                }
                else
                {
                    GetSonNodes(newNode, item);
                }
            }
        }
    }
}

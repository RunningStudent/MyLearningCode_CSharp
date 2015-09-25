using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;

namespace 学习日志记事本
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// //返回选中节点中保存的XELement,巧妙地利用了属性是方法这个特性,实时获得
        /// </summary>
        public XElement selectXNode
        {
            get
            {
                if (treeView1.SelectedNode != null)
                {
                    return treeView1.SelectedNode.Tag as XElement;
                }
                else
                {
                    return null;
                }
            }
        }

        private XDocument document;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗口载入,如果文件不存在会自动生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("QQ.xml"))
            {
                document = XDocument.Load("QQ.xml");
                XElement rootNode = document.Root;
                QuestionInclude(treeView1.Nodes, rootNode);
                //传入treeView集合,和根节点
                this.ActiveControl = tBTitle;//设置焦点
                treeView1.ExpandAll();//展开节点
            }
            else
            {
                document = new XDocument();
                document.Declaration = new XDeclaration("1.0", "utf-8", "yes");
                XElement rootNode = new XElement("Questions");
                document.Add(rootNode);
                AddDateNode(null);//给文档和Treeview加入一个Date节点,节点名称为此时时间
                document.Save("QQ.xml");
            }
        }

        #region 窗口载入时节点载入方法
        /// <summary>
        /// 窗口载入时节点载入方法
        /// </summary>
        /// <param name="treeNodes"></param>
        /// <param name="rootNode"></param>
        private void QuestionInclude(TreeNodeCollection treeNodes, XElement rootNode)
        {
            foreach (var item in rootNode.Elements())
            {
                //遍历根节点集合
                //以集合元素中的Date项的id属性的值,来给treeView添加子节点
                TreeNode sonNode = treeNodes.Add(item.Attribute("id").Value.ToString());
                sonNode.Tag = item;//把Data xml节点对象保存在Data TreeView节点
                if (item.Elements().Count() != 0)//遍历Data的子节点即Q节点,但先判断Data下有无内容
                {
                    foreach (var subitem in item.Elements())
                    {
                        //以Data下的Q下的title的内容,来给Data TreeView节点添加子节点
                        TreeNode sunNode = sonNode.Nodes.Add(subitem.Element("title").Value.ToString());
                        sunNode.Tag = subitem;//同时把Q xml节点保存在TreeView节点中
                        ChangColor(subitem, sunNode);
                    }
                }
            }
        }

        /// <summary>
        /// 改变节点背景色
        /// </summary>
        /// <param name="chooseElement">选择节点所代表的xml元素</param>
        /// <param name="chooseNode">选中的TreeView节点</param>
        private static void ChangColor(XElement chooseElement, TreeNode chooseNode)
        {
            //更加xml文档中所写的属性来给节点赋予相应的颜色
            if (chooseElement.Attribute("isOk").Value == "False")
            {
                chooseNode.BackColor = Color.Green;
            }
            else
            {
                chooseNode.BackColor = Color.Red;
            }
        }
        #endregion

        /// <summary>
        /// 双击显示内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (selectXNode.Name != "Q")//双击点中非Q节点则无效果
                return;
            cBComplete.Checked = bool.Parse(selectXNode.Attribute("isOk").Value);
            tBTitle.Text = selectXNode.Element("title").Value;
            tBbody.Text = selectXNode.Element("desc").Value;
        }

        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            selectXNode.SetAttributeValue("isOk", cBComplete.Checked.ToString());
            selectXNode.SetElementValue("title", tBTitle.Text);
            selectXNode.SetElementValue("desc", tBbody.Text);
            ChangColor(selectXNode, treeView1.SelectedNode);
            document.Save("QQ.xml");
            MessageBox.Show("OK");
        }

        /// <summary>
        /// 右键删除菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            selectXNode.Remove();
            treeView1.SelectedNode.Remove();
            document.Save("QQ.xml");
            tBTitle.Text = "";
            tBbody.Text = "";
        }

        /// <summary>
        /// 添加按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            XElement titleNode = new XElement("title", tBTitle.Text);
            XElement bodyNode = new XElement("desc", tBbody.Text);
            XElement newQNode = new XElement("Q", titleNode, bodyNode);
            newQNode.SetAttributeValue("isOk", cBComplete.Checked.ToString());
            
            //当没选择1级节点或不选时
            if (selectXNode == null || selectXNode.Name != "Date")
            {
                //先判断今日的Date节点是否存在,如果存在则把选中节点设置为它
                bool exist = false;
                foreach (TreeNode item in treeView1.Nodes)
                {
                    if (item.Text == DateTime.Now.ToString("yyyMMdd"))
                    {
                        exist = true;
                        treeView1.SelectedNode = item;
                        break;
                    }
                }

                if (exist)
                {
                    selectXNode.Add(newQNode);
                    TreeNode newTreeNode = treeView1.SelectedNode.Nodes.Add(tBTitle.Text);
                    ChangColor(newQNode, newTreeNode);
                    newTreeNode.Tag = newQNode;
                    MessageBox.Show(string.Format("成功在{0}添加", selectXNode.Attribute("id").Value));
                }
                else//不存在则新增当天日期的节点,并把这篇日志加入
                {
                    AddDateNode(newQNode);
                    MessageBox.Show(string.Format("成功在{0}添加", DateTime.Now.ToString("yyyMMdd")));
                }
            }
            else if (selectXNode.Name == "Date")
            {
                selectXNode.Add(newQNode);
                TreeNode newTreeNode = treeView1.SelectedNode.Nodes.Add(tBTitle.Text);
                newTreeNode.Tag = newQNode;
                ChangColor(newQNode, newTreeNode);
                MessageBox.Show(string.Format("成功在{0}添加", selectXNode.Attribute("id").Value));
            }
            document.Save("QQ.xml");
        }

        
        /// <summary>
        /// 添加Date节点
        /// </summary>
        /// <param name="newQNode"></param>
        private void AddDateNode(XElement newQNode)
        {
            //在创建空xml文档时用到这个方法,所以会有很多判断newNode是否为空
            //新建Date xml节点,设置其属性
            XElement Date = new XElement("Date");
            if (newQNode != null)
            {
                Date.Add(newQNode);
            }
            Date.SetAttributeValue("id", DateTime.Now.ToString("yyyMMdd"));
            //开始新建Date TreeNode,及其子节点
            TreeNode newDataTreeNode = treeView1.Nodes.Add(DateTime.Now.ToString("yyyMMdd"));
            newDataTreeNode.Tag = Date;
            if (newQNode != null)
            {
                TreeNode newTreeNode = newDataTreeNode.Nodes.Add(tBTitle.Text);
                newTreeNode.Tag = newQNode;
                ChangColor(newQNode, newTreeNode);
            }
            //保存
            document.Root.Add(Date);
        }

        

        //右键某TreeView节点时,不会选中节点,于是有这个事件
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
        }
    }
}
